using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet02 : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody rigid;
    private void Start()
    {
        // 이 스크립트가 달린 오브젝트를 2초 뒤에 삭제
        Destroy(gameObject, 2f);
        
        // Rigidbody 를 이용해 날리기
        // 1. 힘 가해주기 : AddForce
        // 2. 속도 설정하기 : velocity
        // 3. 회전력 가해주기 : AddTorque
        // 4. 회전속도 설정하기 : angularVelocity
        // 앞방향 포워드 방향으로 스피드만큼 날려준다, 속도를 정해주고 날려주는 구문
        rigid.velocity = transform.forward * moveSpeed;
    }
}
