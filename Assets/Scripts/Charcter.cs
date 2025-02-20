using UnityEngine;

public class Charcter : MonoBehaviour
{
    /*
    public Animator animator;
    //일반적인 방치형게임의 체력이나 공격력 등의 수치는
    //매우 높은편에 속함
    public double Hp;
    public double ATK;
    //공격속도는 너무 높으면 문제가 될수 있음
    public float attack_speed;

    protected float attack_range;//공격 범위
    protected float target_range;//타겟에 대한 범위
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
    }
    protected void SetMotionChange(string motion_name, bool param)
    {
        animator.SetBool(motion_name, param);

    }

    protected void Thrown()
    {

    }

    protected Transform target;
    // 타겟을 찾는 기능 
    protected void TargetSearch<T>(T[] targets) where T: Component
    {
        var units = targets;// 전달받은 값을 통해 할당
        Transform closet = null;// 가장 가까운 값은 현재 null
        float max_distance = target_range;//최대 거리 == 타겟의 거리
        
        //타겟들 전체를 대상으로 거리를 체크합니다.

        foreach(var unit in units)
        {
            //상대와의 거리체크
            float distance = Vector3.Distance(transform.position, unit.transform.position);
            
            //타겟 거리 보다 작으면 가장 가까운길 
            if(distance < max_distance)
            {
                closet = unit.transform;
                max_distance = distance;
            }
        }

        //타겟 적용
        target =closet;
        
        // 타겟을 응시합니다.
        if(target != null)
        {
            transform.LookAt(target.position);
        }

      
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    */
}
