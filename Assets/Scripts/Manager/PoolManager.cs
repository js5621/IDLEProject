using UnityEngine;
using System.Collections.Generic;
using System;
//Ǯ�� ���� �۾��� �ʿ��� �������� �����ϰ� �ִ� �������̽�

// ��� �̸� �Ҵ��صδ� ����̱⶧���� �޸𸮸� ����ؼ� ������ ���̴� ���
// Ǯ�� ���� �۾��� �ʿ��� �������� �����ϰ� �ִ� �������̽�
public interface IPool
{
    //Property
    Transform parent { get; set; }
    Queue<GameObject> pool { get; set; }//FIFO( first in first out)
    //Function
    //default parameter : ���� ���� ���� �ʾ��� ��� ������ ������ �ڵ� ó���˴ϴ�
    //ex) var go = GetGameObject();
    //ex) var go = GetGameObject(action);
    //���͸� �������� ���
    GameObject GetGameObject(Action<GameObject> action= null); // action �⺻ ���� delegate
    // ���͸� �ݳ��ϴ� ���
    void ObjectReturn(GameObject gameObject,Action<GameObject> action= null);   
   
}

public class ObjectPool : IPool
{
    public Transform parent { get; set; }
    public Queue<GameObject> pool { get; set; } = new Queue<GameObject>();

    public GameObject GetGameObject(Action<GameObject> action = null)
    {
        var obj =pool.Dequeue();// Ǯ���ִ� �� �ϳ� �����ڽ��ϴ�.
        obj.SetActive(true);

        if(action != null)
        {
            action?.Invoke(obj);
            // ���޹��� �׼��� �����մϴ�.
            //?��  null�� ���� ����
        }

        return obj; 
    }

    public void ObjectReturn(GameObject ob, Action<GameObject> action = null)
    {
        pool.Enqueue(ob);
        ob.transform.parent = parent;   
        ob.SetActive(false);
        if (action != null)
        {
            action?.Invoke(ob);
            // ���޹��� �׼��� �����մϴ�.
            //?��  null�� ���� ����
        }
    }

   
}

public class PoolManager : MonoBehaviour
{
    public Dictionary<string,IPool> pool_dict = new Dictionary<string,IPool>();
    //Ű: ��Ʈ��
    //���: Ipool

    public IPool PoolObject(string path)
    {
        //�ش� Ű�� ���ٸ� �߰��� �����մϴ�.
        if(!pool_dict.ContainsKey(path))
        {
            Add(path);
        }
        // ť�� ���� ��� ť �߰�
        if (pool_dict[path].pool.Count <= 0)
        {
            AddQ(path);
        }
        return pool_dict[path];
        //��ųʸ���[Ű] = ��;

    }

    public GameObject Add(string path)
    {
        var obj = new GameObject(path+ "Pool");
        // ���޹��� �̸����� Ǯ ������Ʈ ����
        ObjectPool object_pool = new ObjectPool();
        //������Ʈ Ǯ ����

        pool_dict.Add(path, object_pool);   
        // ��ο� ������Ʈ Ǯ�� ��ųʸ��� ����

        object_pool.parent = obj.transform;
        // Ʈ������ ����
        return obj; 

    }

    public void AddQ(string path)
    {
        var go = Manager.instance.CreateFromPath(path);
        go.transform.parent =pool_dict[path].parent;
        pool_dict[path].ObjectReturn(go);
    }
    
}
