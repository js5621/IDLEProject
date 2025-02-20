using UnityEngine;

public class Manager : MonoBehaviour
{
    //싱글톤 개발
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

    //Resources 폴더가 반드시 필요한 코드
    public GameObject CreateFromPath(string path)
    {
        return Instantiate(Resources.Load<GameObject>(path));
    }
}
