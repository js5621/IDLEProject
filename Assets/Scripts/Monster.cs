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
        Debug.Log("���Ͱ� �����Ǿ����ϴ�.");
    }

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(playerPrefab.transform.position);
        Debug.Log(playerPrefab.transform.position);

        float targer_distance = Vector3.Distance(enemyAnimator.transform.position, playerPrefab.transform.position);
        if (targer_distance <= rate)// ���� �Ÿ��� ��������� �̵� ����
        {
            SetMotionChange("isMove", false);
        }
        
        else //�Ϲ����� ��쿡�� �������� ����
        {
            //���� �������� �ü�����
            transform.position = Vector3.MoveTowards(transform.position, playerPrefab.transform.position, Time.deltaTime * monster_speed);
            //��������, ������ �ӵ���ŭ ������ �̵��մϴ�.
            SetMotionChange("isMove", true);
        }

        
    }
    protected void SetMotionChange(string motion_name, bool param)
    {
        enemyAnimator.SetBool(motion_name, param);

    }

}
