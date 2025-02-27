using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Net;
using System.Threading;
using UnityEngine;
using UnityEngine.TextCore.Text;
using Random = UnityEngine.Random;

public class Monster : Charcter
{
    public float monster_speed;
   // Animator enemyAnimator;
    public float rate =0.5f;
    public PlayerSo playerSo;
    bool isRandomMove =false;
    bool isAlive = true;
    bool isUniComplete =false;
    MovementInput jammoLocation;
    Spawner monsterSpawner;
    public SpawnSO spawnSo;
    Rigidbody alienRigid;
    CancellationTokenSource destroyCancellation = new CancellationTokenSource();
    Vector3 playerVector;

    private RaycastHit hit; 
    private float maxDistance = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async void Start()
    {
        jammoLocation= GameObject.Find("Jammo_Player").GetComponent<MovementInput>();
        monsterSpawner =GameObject.FindAnyObjectByType<Spawner>();
        alienRigid = GetComponent<Rigidbody>();
        
        //enemyAnimator = GetComponent<Animator>();   
    }



    public void MonsterSample()
    {
        Debug.Log("몬스터가 생성되었습니다.");
    }

    // Update is called once per frame
    async void Update()
    {
        playerVector = jammoLocation.transform.position;
        //transform.LookAt(playerVector);



        if (monsterSpawner.isMonsterMove)
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
            {

                transform.position = Vector3.MoveTowards(transform.position, playerVector, Time.deltaTime * monster_speed);
            }
            else
            {

               // await EnemyMoveSequence().SuppressCancellationThrow(); 
            }



        }
        if (monsterSpawner.isMonsterSequenceEnd)
        {
            Destroy(this.gameObject, 0.5f);
        }





    }

    private async void FixedUpdate()
    {
       
    }

    async UniTask EnemyMoveSequence()
    {
        if (!isAlive)
            return;
        else
        {
            try
            {
                isUniComplete = false;
                if(alienRigid != null)
                    alienRigid.AddForce(Vector3.forward + (Vector3)Random.insideUnitCircle, ForceMode.Impulse);
                await UniTask.Delay(100);
                if(alienRigid != null)
                    alienRigid.AddForce(Vector3.back + (Vector3)Random.insideUnitCircle, ForceMode.Impulse);
                await UniTask.Delay(100);
                isUniComplete = true;

            }

            catch (Exception ex)
            {
                Debug.LogException(ex);
            }
            
            finally
            {
              
            }
        }

     
    }

    

    private void OnCollisionEnter(Collision collision)
    {

     
        if (collision.gameObject.tag =="Player")
        {
            if (playerSo.playerHp >0)
            {
                playerSo.playerHp -= 1;
            }
            if(spawnSo.SpawnMonsterCount > 0)
            {
                spawnSo.SpawnMonsterCount -= 1;
            }
            isAlive =false;
        
            Destroy(this.gameObject, 0.5f);
            
            
        }
    }
    

}
