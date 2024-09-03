using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster05 : MonoBehaviour
{
    // 플레이어의 Transform을 찾아주기
    [SerializeField] Transform playerTransform;
    [SerializeField] float sightDistance;
    [SerializeField] bool isDetect;
    [SerializeField] float moveSpeed;

    private void Start()
    {
        // 태그로 찾는 방법. 태그 찾기를 추천한다, 특정 게임오브젝트 찾기.
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        // 플레이어의 위치를 가져왔다.
        playerTransform = playerGameObject.transform;
    }

    private void Update()
    {
        if (playerTransform != null) 
        {
            Look();
        }
        if (isDetect == true) 
        {
            Trace();
        }
    }

    private void Trace()
    {
        //MoveTowards(시작위치, 목표위치, 이동속도*Time.deltaTime)
        // 포워드 방향으로 이동해도 상관없다. 어차피 몬스터는 플레이어를 정면으로 쳐다볼테니
        // 그래서 포워드 방식으로 해도 Translate로 해도 상관없다
        // 둘다 같은 결과를 낼거다
        // transform.Translate(transform.forward*moveSpeed*Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, moveSpeed*Time.deltaTime);
    }

    public void Look()
    {
        // 플레이어가 있는 위치(position)를 바라보기
        transform.LookAt(playerTransform.position);

        // 반환형이 부딪힌 여부 Bollean
        // Raycast(시작위치, 어디방향으로, out RaycastHit(부딪혔다), 거리, 레이어마스크)
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, sightDistance)) 
        {
            // 레이캐스트가 부딪힌 경우
            // DrawRay(시작위치, 쏘는방향으로 거리를 곱해주고, 색상넣어주기)
            Debug.DrawRay(transform.position, transform.forward * hitInfo.distance,Color.red);
            // 레이캐스트에 부딪힌 게임오브젝트
            GameObject raycastHitGameObject = hitInfo.collider.gameObject;
            // 레이캐스트에 부딪힌 게임오브젝트가 플레이어였다면
            if (raycastHitGameObject.tag == "Player") 
            {
                // 플레이어가 맞다에 체크
                isDetect = true;
            }
            else
            {
                // 시야거리에 안닿다 그래서 체크해제
                isDetect= false;
            }
        }
        else
        {
            // 레이캐스트가 부딪히지 못한 경우
            // 어디까지 쏠 수 있는지 정하기
            Debug.DrawRay(transform.position, transform.forward * sightDistance, Color.red);
        }
    }

    public void TakeHit()
    {
        // 몬스터는 피격시에 바로 삭제되도록.
        Destroy(gameObject);
    }
}
