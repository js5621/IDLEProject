using UnityEngine;

public class Manager : MonoBehaviour
{
    //�̱��� ����
    public static Manager instance;

    private static PoolManager poolManager = new PoolManager();
    public static PoolManager POOL
    {
        get
        {
            return poolManager;
        }
    }

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        if (instance == null)
        {
            instance= this;
            DontDestroyOnLoad(gameObject);  
        }
        else
        {
            Destroy(gameObject);
        }

    }

    //Resources ������ �ݵ�� �ʿ��� �ڵ�
    public GameObject CreateFromPath(string path)
    {
        return Instantiate(Resources.Load<GameObject>(path));
    }
}
