using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // ī�޶� ���� �÷��̾� ���� �۾� 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Transform playerTransform;
    Vector3 Offset; // ī�޶�� �÷��̾� ������ �Ÿ� ����

    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Offset = transform.position - playerTransform.position; //ī�޶� ��ġ - �÷��̾� ��ġ    
    }

    void LateUpdate()
    {
        transform.position = playerTransform.position + Offset; //ī�޶� ��ġ = �÷��̾� ��ġ + �Ÿ�
    }
}
