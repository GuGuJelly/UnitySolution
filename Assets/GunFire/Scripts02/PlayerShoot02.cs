using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot02 : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;// 이 총알을 생성
    [SerializeField] Transform muzzlePoint;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            // Instantiate(프리팹, 위치, 회전)
            // 머즐포인트에서의 위치에, 그리고 그 회전으로 생성시킴.
            Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
        }
    }
}
