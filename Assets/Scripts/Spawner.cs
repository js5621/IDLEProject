
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;


public class Spawner : MonoBehaviour
{
    // 몬스터를 맵에 특정마리수를 몇 초마다 반복해서 소환합니다.

    public GameObject monster_prefab;
    public int monster_count;
    public int goalPoint =30;
    public PlayerSo playerSo;
    int secondToMili =1000;
    public float monster_spawn_time;
    public Transform spawnTransform;
    public float summon_rate = 5.0f; //해당 수치를 수정할경우 생성되는 영역(구)의 위치값이 점점넓어집니다.
    public float re_Rate = 20f;//생성 위치를 기준으로 생성되는 영역(구)를 설정할 수 있습니다.



    public static List<Monster> monster_list = new List<Monster>();//생성된 몬스터
    public static List<Player> player_list = new List<Player>();//생성된 캐릭터
    public GameObject monsterSpawnText;
    public GameObject successOrFailText;

    public bool isSpawnControl= false;
    public bool isgameOVer =false;
    public bool isMonsterMove;
    public bool isMonsterSequenceEnd=false;

    public bool isGamePlay =false;

    public bool isLightReset = true;// 불빛 제어


    public SpawnSO spawnSO;
    Vector3 tempVector;

    async private void Start()
    {

        spawnSO.recentPoint = 0;
        //StartCoroutine("SpawnMonster");
         await MonsterSpawn();

    }

    private async void Update()
    {
        if(playerSo.playerHp==0)
        {
            GameOVer();
        }


    }

    async void GameOVer()
    {
        if (isgameOVer)
        {
            return;

        }

        isgameOVer = true;
        await UniTask.Delay(500);

        successOrFailText.SetActive(true);
        successOrFailText.GetComponent<Text>().text = $"F A I L\nSCORE\n{spawnSO.recentPoint}";


    }
    async UniTask MonsterSpawn()
    {
        if (isSpawnControl)
        {
            return;
        }
        // 준비 시퀀스 시작
        isGamePlay = true;
        isLightReset = true;
        await UniTask.Delay(1000);
        isMonsterSequenceEnd = false;
        await UniTask.Delay(100);
        successOrFailText.SetActive(true);
        successOrFailText.GetComponent<Text>().text = "ALIEN\nAPPEAR!";
        await UniTask.Delay(1000);
        successOrFailText.SetActive(false);
        await UniTask.Delay(1000);

        tempVector = spawnTransform.position;
        Vector3 pos;


        for (int i = 0; i < monster_count; i++)
        {
            pos = tempVector + Random.insideUnitSphere * summon_rate;
            pos.y = 2;

            GameObject go = Instantiate(monster_prefab, pos, Quaternion.identity);
            await UniTask.Delay(100);
        }

        await UniTask.Delay(500);

        successOrFailText.GetComponent<Text>().text = "Survive!";
        await UniTask.Delay(1000);
        successOrFailText.SetActive(true);
        await UniTask.Delay(1000);
        successOrFailText.SetActive(false);





        await UniTask.Delay(100);
        isSpawnControl = true;
        monsterSpawnText.SetActive(true);

        for (int i = 3; i > 0; i--)
        {
            monsterSpawnText.GetComponent<Text>().text = i.ToString();
            await UniTask.Delay(1000);
        }
        monsterSpawnText.SetActive(false);

        await UniTask.Delay(1000);
        isMonsterMove = true;
        isLightReset = false;







        // 준비 시퀀스 끝
        await UniTask.Delay((int)monster_spawn_time*secondToMili);
        if (playerSo.playerHp == 0)
        {
            return;
        }
        monsterSpawnText.SetActive(true);
        for (int i = 10; i > 0; i--)
        {
            monsterSpawnText.GetComponent<Text>().text = i.ToString();
            await UniTask.Delay(1000);
        }
        monsterSpawnText.SetActive(false);




        successOrFailText.GetComponent<Text>().text = "SUCESS";
        isMonsterMove = false;
        await UniTask.Delay(200);
        isMonsterSequenceEnd = true;
        await UniTask.Delay(1000);
        successOrFailText.SetActive(false);
        isSpawnControl = false;

        monster_count++;
        playerSo.playerStage++;
        isGamePlay = false;





        // 클리어 판정
        successOrFailText.SetActive(true) ;

        MonsterSpawn();
    }
    IEnumerator SpawnMonster()
    {

        tempVector = spawnTransform.position;
        Vector3 pos;
        for (int i = 0; i < monster_count; i++)
        {
            pos = tempVector + Random.insideUnitSphere * Random.Range(0.0f, summon_rate)+new Vector3(1,1,1)*0.2f;
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

}

