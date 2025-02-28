# ASTRO SURVIVOR

## 개요
위의 게임은 외계인 적들의 추적을 피하여 적들을 없애거나 피하여 생존하는 게임입니다.

## 목차
1. [게임의 룰](#게임의-룰)
2. [게임의 오브젝트](#게임의-오브젝트)
3. [게임의 주요 개발 요소](#게임의-주요-개발-요소)
4. [게임 개발 방향성의 변화](#게임-개발-방향성의-변화)
5. [개발 후기](#개발-후기)

## 1. 게임의 룰
- 일정한 시간마다 ALIEN(적 외계인)이 생성됩니다. 생성될 때마다 외계인을 피하거나 외계인을 없애서 점수를 획득하는 방식으로 스테이지에서 생존합니다.
- HP가 0이 되었을 때 게임이 종료되며, 그때 마지막으로 기록된 스테이지와 점수가 기록으로 남습니다.

## 2. 게임의 오브젝트
### 2-1. 플레이어
- 이 게임의 성공과 실패가 적용되는 플레이어블 캐릭터입니다.
- 전, 후, 좌, 우로 움직일 수 있습니다.
- ALIEN과 충돌하면 HP가 0이 되며 게임이 종료됩니다.
- 바닥 LIGHT와 접근하여 빨간색에서 초록색으로 만들 수 있습니다.

### 2-2. ALIEN
- 플레이어를 공격하는 적입니다.
- 플레이어를 탐지하는 로직으로 플레이어를 추적합니다.
- 플레이어에게 충돌하면 플레이어의 HP가 0이 되며, 바닥 LIGHT의 초록색에 닿으면 소멸 판정됩니다.

### 2-3. Light
- 스테이지 바닥에 위치합니다.
- 플레이어가 더 오래 생존하게 하는 게임 장치입니다.

## 3. 게임의 주요 개발 요소
### 3-1. 플레이어의 개발 요소
#### 플레이어의 이동
- 플레이어는 캐릭터 컴포넌트를 사용하여 이동합니다.
- `InputMagnitude()` 함수로 캐릭터 방향을 입력받으며, 입력된 이동 방향으로 이동됩니다.
```csharp
void InputMagnitude()
{
    //Calculate Input Vectors
    InputX = Input.GetAxis("Horizontal");
    InputZ = Input.GetAxis("Vertical");

    //Calculate the Input Magnitude
    Speed = new Vector3(InputX, InputZ).sqrMagnitude;

    //Physically move player
    if (Speed > allowPlayerRotation)
    {
        playerAnimator.SetBool("isRunning", true);
        playerAnimator.SetBool("isIDLE", false);
        PlayerMoveAndRotation();
    }
    else if (Speed < allowPlayerRotation)
    {
        playerAnimator.SetBool("isRunning", false);
        playerAnimator.SetBool("isIDLE", true);
    }
}
PlayerMoveAndRotation() 함수를 사용하여 캐릭터의 방향 회전을 구현합니다.
csharp
복사
void PlayerMoveAndRotation()
{
    InputX = Input.GetAxis("Horizontal");
    InputZ = Input.GetAxis("Vertical");

    var camera = Camera.main;
    var forward = cam.transform.forward;
    var right = cam.transform.right;

    forward.y = 0f;
    right.y = 0f;

    forward.Normalize();
    right.Normalize();

    desiredMoveDirection = forward * InputZ + right * InputX;

    if (!blockRotationPlayer)
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(desiredMoveDirection), desiredRotationSpeed);
        controller.Move(desiredMoveDirection * Time.deltaTime * Velocity);
    }
}
3-2. ALIEN의 개발 요소
적의 플레이어 탐지 및 이동
ALIEN은 플레이어가 탐지되지 않았을 때 AddForce를 통해 이동하며, Raycast를 통해 플레이어를 탐지한 후 추적합니다.
csharp
복사
if (monsterSpawner.isMonsterMove)
{
    if (Physics.Raycast(transform.position, transform.forward, out hit, maxDistance))
    {
        transform.position = Vector3.MoveTowards(transform.position, playerVector, Time.deltaTime * monster_speed);
    }
    else
    {
        await EnemyMoveSequence().SuppressCancellationThrow();
    }
}
3-3. Light의 개발 요소
Collider의 isTrigger를 이용하여 플레이어가 바닥 빛이 적색일 때는 초록색으로 만들고, 초록색일 때 ALIEN이 지나가면 ALIEN이 소멸된 후 다시 빨간색으로 바뀌도록 구현합니다.
csharp
복사
private void OnTriggerEnter(Collider other)
{
    if (!spawner.isLightReset)
    {
        if (other.gameObject.tag == "Player")
        {
            this.transform.GetChild(0).GetComponent<Light>().DOColor(Color.green, 0.1f);
        }

        if (other.gameObject.tag == "EnemyAlien")
        {
            if (this.transform.GetChild(0).GetComponent<Light>().color == Color.green)
            {
                Destroy(other.gameObject, 0.5f);
                this.transform.GetChild(0).GetComponent<Light>().DOColor(Color.red, 0.1f);
                spawnSO.recentPoint += 10;
            }
        }
    }
}
4. 게임 개발 방향성의 변화
4-1. 1차 버전: 플레이어 캐릭터 3인칭 시점의 3D 게임 방식
의도: 플레이어를 3D 방식으로 몰입시키고, 점프 구현을 통해 플레이어의 극적인 회피를 구현하고자 했습니다.
변경 이유: 후방에서 다가오는 적 회피가 어려웠고, 캐릭터 컨트롤러를 처음 사용하여 점프 구현에 어려움을 겪었습니다.
4-2. 2차 버전: Orthographic View를 활용한 2.5D 게임 방식
의도: 플레이어의 원활한 시야 확보를 위해 해당 방식으로 변경하였습니다.
변경 이유: 뷰 방식은 변경되지 않았지만, ALIEN이 생성되면 플레이어의 위치로 바로 이동하도록 되어 있어 게임의 단조로움이 느껴졌습니다. 이를 개선하기 위한 방식으로 변경되었습니다.
4-3. 3차 버전: ALIEN의 플레이어 탐지 알고리즘 수정
의도: ALIEN의 이동 탐지 알고리즘을 수정하여, AddForce로 임의의 방향으로 이동하다가 Raycast로 플레이어를 탐지하여 이동하도록 변경했습니다.
변경 이유: Light를 통해 적을 제거하고 점수를 추가하여 플레이어의 동기부여를 증가시켰습니다.
5. 개발 후기
게임의 세밀한 기획 필요: 처음에 게임을 단순하게 기획하여 변경 과정에서 어려움을 많이 겪었습니다. 게임 개발 시 세밀한 계획이 필요하다는 것을 느꼈습니다.
낯선 컴포넌트에 대한 어려움: 캐릭터 컨트롤러를 처음 사용하여 게임 개발에 어려움을 겪었습니다.
추가적인 개발 기간에 대한 아쉬움: 게임 개발 기간이 제한되어 있어 보상 체계를 더 추가할 수 없어 아쉬웠습니다.
게임 제작에 대한 성취감: 게임 기능 구현을 통해 의도한 기능이 잘 구현되어 성취감을 느꼈습니다.
