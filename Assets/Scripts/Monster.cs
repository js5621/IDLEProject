using System;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Monster : Charcter
{
    public float monster_speed;
   // Animator enemyAnimator;
    public float rate =0.5f;
    MovementInput jammoLocation;
    Vector3 playerVector;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     void Start()
    {
        jammoLocation= GameObject.Find("Jammo_Player").GetComponent<MovementInput>();    
        //enemyAnimator = GetComponent<Animator>();   
    }

    public void MonsterSample()
    {
        Debug.Log("몬스터가 생성되었습니다.");
    }

    // Update is called once per frame
    void Update()
    {
        playerVector = jammoLocation.transform.position;    
        //transform.LookAt(playerVector);
      

        float targer_distance = Vector3.Distance(transform.position, playerVector);
        if (targer_distance <= rate)// 간격 거리와 가까워지면 이동 중지
        {
            monster_speed = 0.0f;
           // SetMotionChange("isMove", false);
        }
        
        else //일반적인 경우에는 움직임을 진행
        {
            //영점 기준으로 시선변경
            transform.position = Vector3.MoveTowards(transform.position, playerVector, Time.deltaTime * monster_speed);
            //영점으로, 몬스터의 속도만큼 앞으로 이동합니다.
            //SetMotionChange("isMove", true);
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag =="Environment")
        {
            Destroy(this.gameObject);   
        }
    }
    //protected void SetMotionChange(string motion_name, bool param)
    //{
    //    enemyAnimator.SetBool(motion_name, param);

    //}

}
