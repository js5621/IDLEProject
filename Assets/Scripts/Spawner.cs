
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // 몬스터를 맵에 특정마리수를 몇 초마다 반복해서 소환합니다.
  
    public GameObject monster_prefab;
    public int monster_count;
    public float monster_spawn_time;
    public Transform playerTransform;
    public float summon_rate = 5.0f; //해당 수치를 수정할경우 생성되는 영역(구)의 위치값이 점점넓어집니다.
    public float re_Rate = 20f;//생성 위치를 기준으로 생성되는 영역(구)를 설정할 수 있습니다.


    public static List<Monster> monster_list = new List<Monster>();//생성된 몬스터
    public static List<Player> player_list = new List<Player>();//생성된 캐릭터
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
            pos.y = 0.0f;// 생성된 유닛이 맵에 제대로 존재하기 위해 설정
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
                //생성한 유닛을 몬스터에 추가 

            }); //전달할 함수가 있는 경우 Action<GameObject>

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

