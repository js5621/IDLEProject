using System;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Monster : Charcter
{
    public float monster_speed;
    Animator enemyAnimator;
    public float rate =0.5f;
    public GameObject playerPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     void Start()
    {
        
        enemyAnimator = GetComponent<Animator>();   
    }

    public void MonsterSample()
    {
        Debug.Log("몬스터가 생성되었습니다.");
    }

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(playerPrefab.transform.position);
        Debug.Log(playerPrefab.transform.position);

        float targer_distance = Vector3.Distance(enemyAnimator.transform.position, playerPrefab.transform.position);
        if (targer_distance <= rate)// 간격 거리와 가까워지면 이동 중지
        {
            SetMotionChange("isMove", false);
        }
        
        else //일반적인 경우에는 움직임을 진행
        {
            //영점 기준으로 시선변경
            transform.position = Vector3.MoveTowards(transform.position, playerPrefab.transform.position, Time.deltaTime * monster_speed);
            //영점으로, 몬스터의 속도만큼 앞으로 이동합니다.
            SetMotionChange("isMove", true);
        }

        
    }
    protected void SetMotionChange(string motion_name, bool param)
    {
        enemyAnimator.SetBool(motion_name, param);

    }

}
