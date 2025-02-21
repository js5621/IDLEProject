using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // 카메라 시점 플레이어 고정 작업 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Transform playerTransform;
    Vector3 Offset; // 카메라와 플레이어 사이의 거리 변수

    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Offset = transform.position - playerTransform.position; //카메라 위치 - 플레이어 위치    
    }

    void LateUpdate()
    {
        transform.position = playerTransform.position + Offset; //카메라 위치 = 플레이어 위치 + 거리
    }
}
