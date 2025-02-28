using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class Player2 : MonoBehaviour
{
    public float Velocity;
    public float InputX;
    public float InputZ;

    public float speed;      // 캐릭터 움직임 스피드.
    public float jumpSpeedF; // 캐릭터 점프 힘.
    public float gravity;    // 캐릭터에게 작용하는 중력.
    public float allowPlayerRotation = 0.1f;
    public float desiredRotationSpeed = 0.1f;

    private Vector3 MoveDir;
    public Vector3 desiredMoveDirection;// 캐릭터의 움직이는 방향.
    public float Speed;//import
    public Camera cam;
    private CharacterController controller; // 현재 캐릭터가 가지고있는 캐릭터 컨트롤러 콜라이더.
    Animator playerAnimator;
    public bool blockRotationPlayer;
    public PlayerSo playerSo;

    void Start()
    {
        speed = 6.0f;
        jumpSpeedF = 8.0f;
        gravity = 20.0f;
        cam = Camera.main;

        MoveDir = Vector3.zero;
        controller = GetComponent<CharacterController>();
        playerAnimator = GetComponent<Animator>();
        playerSo.playerHp = 15;
        playerSo.playerStage = 1;   
    }

    void Update()
    {
        InputMagnitude();
        // 현재 캐릭터가 땅에 있는가?
        if (controller.isGrounded)
        {
            // 위, 아래 움직임 셋팅. 
            MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            // 벡터를 로컬 좌표계 기준에서 월드 좌표계 기준으로 변환한다.
            MoveDir = transform.TransformDirection(MoveDir);

            // 스피드 증가.
            MoveDir *= speed;

            //// 캐릭터 점프
            //if (Input.GetButton("Jump"))
            //{
            //    MoveDir.y = jumpSpeedF;
            //    playerAnimator.SetBool("isJump", true);
            //    playerAnimator.SetBool("isIDLE",false);
                
                
            //}
               

        }

        // 캐릭터에 중력 적용.
        MoveDir.y -= gravity * Time.deltaTime;
        
        // 캐릭터 움직임.
        controller.Move(MoveDir * Time.deltaTime);
        
    }
    void InputMagnitude()
    {
        //Calculate Input Vectors
        InputX = Input.GetAxis("Horizontal");

        InputZ = Input.GetAxis("Vertical");

        //anim.SetFloat ("InputZ", InputZ, VerticalAnimTime, Time.deltaTime * 2f);
        //anim.SetFloat ("InputX", InputX, HorizontalAnimSmoothTime, Time.deltaTime * 2f);

        //Calculate the Input Magnitude
        Speed = new Vector3(InputX, InputZ).sqrMagnitude;

        //Physically move player


        if (Speed > allowPlayerRotation)
        {
            playerAnimator.SetBool("isRunning",true);
            playerAnimator.SetBool("isIDLE", false);


            PlayerMoveAndRotation();
        }
        else if (Speed < allowPlayerRotation)
        {
            playerAnimator.SetBool("isRunning", false);
            playerAnimator.SetBool("isIDLE", true); 
            
        }
    }

    void PlayerMoveAndRotation()
    {
        InputX = Input.GetAxis("Horizontal");

        InputZ = Input.GetAxis("Vertical");

        var camera = Camera.main;
        var forward = cam.transform.forward;
        var up = cam.transform.up;
        var right = cam.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        desiredMoveDirection = forward * InputZ + right * InputX;

        if (blockRotationPlayer == false)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
            controller.Move(desiredMoveDirection * Time.deltaTime * Velocity);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if(hit.gameObject.layer ==3)
        {
            if (playerAnimator.GetBool("isJump"))
            {
                playerAnimator.SetBool("isIDLE", true);
                playerAnimator.SetBool("isJump", false);
            }

        }

    }

}