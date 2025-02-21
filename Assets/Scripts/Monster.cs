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
        Debug.Log("���Ͱ� �����Ǿ����ϴ�.");
    }

    // Update is called once per frame
    void Update()
    {
        playerVector = jammoLocation.transform.position;    
        //transform.LookAt(playerVector);
      

        float targer_distance = Vector3.Distance(transform.position, playerVector);
        if (targer_distance <= rate)// ���� �Ÿ��� ��������� �̵� ����
        {
            monster_speed = 0.0f;
           // SetMotionChange("isMove", false);
        }
        
        else //�Ϲ����� ��쿡�� �������� ����
        {
            //���� �������� �ü�����
            transform.position = Vector3.MoveTowards(transform.position, playerVector, Time.deltaTime * monster_speed);
            //��������, ������ �ӵ���ŭ ������ �̵��մϴ�.
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
