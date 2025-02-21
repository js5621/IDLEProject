
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // ���͸� �ʿ� Ư���������� �� �ʸ��� �ݺ��ؼ� ��ȯ�մϴ�.
  
    public GameObject monster_prefab;
    public int monster_count;
    public float monster_spawn_time;
    public Transform playerTransform;
    public float summon_rate = 5.0f; //�ش� ��ġ�� �����Ұ�� �����Ǵ� ����(��)�� ��ġ���� �����о����ϴ�.
    public float re_Rate = 20f;//���� ��ġ�� �������� �����Ǵ� ����(��)�� ������ �� �ֽ��ϴ�.


    public static List<Monster> monster_list = new List<Monster>();//������ ����
    public static List<Player> player_list = new List<Player>();//������ ĳ����
    Vector3 tempVector;

    private void Start()
    {
        
        StartCoroutine("SpawnMonster");
        
    }
    IEnumerator SpawnMonster()
    {
        tempVector = playerTransform.position;
        Vector3 pos;
        for (int i = 0; i < monster_count; i++)
        {
            pos = tempVector +Random.insideUnitSphere*summon_rate;
            pos.y = 2;
            /*
            while(Vector3.Distance(pos,playerTransform.position)<= re_Rate)
            {
                pos = Vector3.zero + Random.insideUnitSphere * summon_rate;
                pos.y = 0.0f;
            }
            */
            GameObject go =Instantiate(monster_prefab,pos,Quaternion.identity);
        }
        yield return new WaitForSeconds(monster_spawn_time);
        StartCoroutine("SpawnMonster");
    }
    /*
    IEnumerator SpawnMonsterPooling()
    {
        Vector3 pos;
        for (int i = 0; i < monster_count; i++)
        {
            pos =playerTransform.position + Random.insideUnitSphere * summon_rate;
            pos.y = 0.0f;// ������ ������ �ʿ� ����� �����ϱ� ���� ����
            while (Vector3.Distance(pos, playerTransform.position) <= re_Rate)
            {
                pos = playerTransform.position + Random.insideUnitSphere * summon_rate;
                pos.y = 0.0f;
            }
           // var go = Manager.POOL.PoolObject("EnemyRobot").GetGameObject((
            var go = Manager.POOL.PoolObject("SpehereAlien").GetGameObject((result)=>
            {
                //result.GetComponent<Monster>().MonsterSample();
                result.transform.position = pos;
                result.transform.LookAt(playerTransform.position);
                monster_list.Add(result.GetComponent<Monster>());
                //������ ������ ���Ϳ� �߰� 

            }); //������ �Լ��� �ִ� ��� Action<GameObject>

            StartCoroutine(ReturnMonsterPooling(go));


        }
        yield return new WaitForSeconds(monster_spawn_time);
        StartCoroutine("SpawnMonsterPooling");
    }

    IEnumerator ReturnMonsterPooling(GameObject ob)
    {
        yield return new WaitForSeconds(10.0f);
        Manager.POOL.pool_dict["EnemyRobot"].ObjectReturn(ob);  
    }
    */
}

