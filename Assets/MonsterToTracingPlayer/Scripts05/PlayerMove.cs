using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(x, 0, z);
        // 입력방향이 없을 때는, 벡터가 0일 때는 움직이지 않게 해주자
        if (dir == Vector3.zero)
            return;
        // 성능이 많이 빠르. 그래서 스퀘어마그네틱을 써주자
        if (dir.sqrMagnitude > 1)
        {
            // 단위벡터화
            // 대각선에서 더 빨리 이동하지 못하게 하는 조치.
            dir.Normalize();
        }

        // 이동 방법
        // 1. 방향으로 이동하기 position, Translate
        // 2. 목적지를 지정해서 이동하기 MoveToWard
        // 3. 목적지를 향해 다가가면 갈수록 점점 느려지는 이동법  Lerp
        // 어딜 바라봐도 세상을 기준좌표계를 기준으로 움직이게 해주는 Space.World
        transform.Translate(dir * moveSpeed * Time.deltaTime, Space.World);

        // 회전방법
        // 1. 축을 기준으로 각도 돌리기 Rotate
        // 2. 기준점을 기준으로 돌리기 RotateAround
        // 3. 기준점을 바라보도록 돌리기 LookAt
        // 4. 회전 설정해주기 transform.rotation = Quarternion; 회전은 쿼터니언으로 만들어져 있다
        // dir 방향으로 돌아보게 하는 회전
        transform.rotation = Quaternion.LookRotation(dir);
        // 아니면 밑에처럼 슬그머니, 천천히 회전시키는 것도 가능하다 
        // transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.LookRotation(dir), Time.deltaTime);
    }
}
