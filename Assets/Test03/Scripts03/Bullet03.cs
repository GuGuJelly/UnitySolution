using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet03 : MonoBehaviour
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

    private void OnCollisionEnter(Collision collision)
    {
        // 부딪힌 게임오브젝트에 몬스터 컴포넌트가 있는지 가져와라
        // collisio 에 부딪힌 상대방 컴포넌트 정보가 담겨있기 때문에
        Monster03 monster = collision.gameObject.GetComponent<Monster03>();
        if (monster != null)
        {
            // 몬스터가 맞았으면 몬스터 피격함수 불러와서 몬스터 삭제시키고
            monster.TakeHit();
        }

        // 총알은 뭐라도 아무거나 부딪혔을 때 삭제되도록.
        Destroy(gameObject);
    }
}
