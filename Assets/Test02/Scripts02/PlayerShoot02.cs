using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot02 : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;// �� �Ѿ��� ����
    [SerializeField] Transform muzzlePoint;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            // Instantiate(������, ��ġ, ȸ��)
            // ��������Ʈ������ ��ġ��, �׸��� �� ȸ������ ������Ŵ.
            Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
        }
    }
}
