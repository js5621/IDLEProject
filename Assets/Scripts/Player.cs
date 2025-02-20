using UnityEngine;

public class Player : Charcter
{
    /*
    Vector3 start_pos;
    Quaternion rotation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {

        base.Start();

        // #시작값 설정 
        start_pos = transform.position;
        rotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        TargetSearch(Spawner.monster_list.ToArray());
        //리스트명.ToArray()를 통해 list -> array
        if(target == null)
        {
            float pos = Vector3.Distance(transform.position,start_pos);
            if(pos>0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, start_pos, Time.deltaTime * 2.0f);
                transform.LookAt(start_pos);
                SetMotionChange("isMove",true);
            }
            else
            {
                transform.rotation = rotation;
                SetMotionChange("isMove", false);
            }
            return; //작업 종료 
        }

        float distance = Vector3.Distance (transform.position,target.position);
        // 타겟 범위보다 작으면서 공격 범위보다 높은경우 
        if (distance <= target_range && distance > attack_range)
        {
            SetMotionChange("isMove", true);
            transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * 2.0f);
        }

        else if (distance <= attack_range)
        {
            //공격 자세로 넘어갑니다.
            SetMotionChange("isAttack",true);
        }
    }
    */
}
