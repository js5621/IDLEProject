using UnityEngine;

public class Charcter : MonoBehaviour
{
    /*
    public Animator animator;
    //�Ϲ����� ��ġ�������� ü���̳� ���ݷ� ���� ��ġ��
    //�ſ� ������ ����
    public double Hp;
    public double ATK;
    //���ݼӵ��� �ʹ� ������ ������ �ɼ� ����
    public float attack_speed;

    protected float attack_range;//���� ����
    protected float target_range;//Ÿ�ٿ� ���� ����
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
    // Ÿ���� ã�� ��� 
    protected void TargetSearch<T>(T[] targets) where T: Component
    {
        var units = targets;// ���޹��� ���� ���� �Ҵ�
        Transform closet = null;// ���� ����� ���� ���� null
        float max_distance = target_range;//�ִ� �Ÿ� == Ÿ���� �Ÿ�
        
        //Ÿ�ٵ� ��ü�� ������� �Ÿ��� üũ�մϴ�.

        foreach(var unit in units)
        {
            //������ �Ÿ�üũ
            float distance = Vector3.Distance(transform.position, unit.transform.position);
            
            //Ÿ�� �Ÿ� ���� ������ ���� ������ 
            if(distance < max_distance)
            {
                closet = unit.transform;
                max_distance = distance;
            }
        }

        //Ÿ�� ����
        target =closet;
        
        // Ÿ���� �����մϴ�.
        if(target != null)
        {
            transform.LookAt(target.position);
        }

      
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    */
}
