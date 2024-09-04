using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot04 : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform muzzlePoint;
    [SerializeField] float repeatTime;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            // 연사시작
            fireRoutine = StartCoroutine(FireRoutine());

        }else if (Input.GetKeyUp(KeyCode.Space))
        {
            // 연사종료
            // 코루틴 종료는 밑에 선언해놓은 담당자를 써야 한다. 
            StopCoroutine(fireRoutine);
        }

    }

    Coroutine fireRoutine;
    IEnumerator FireRoutine()
    {
        // 이렇게 한번만 선언해주고, 구문에 delay로 쓰는게 성능상 유리하다
        WaitForSeconds delay = new WaitForSeconds(repeatTime);
        while (true)
        {
            // 총알 생성
            Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
            yield return delay;
        }
    }

}
