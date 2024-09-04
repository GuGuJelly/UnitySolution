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
            // �������
            fireRoutine = StartCoroutine(FireRoutine());

        }else if (Input.GetKeyUp(KeyCode.Space))
        {
            // ��������
            // �ڷ�ƾ ����� �ؿ� �����س��� ����ڸ� ��� �Ѵ�. 
            StopCoroutine(fireRoutine);
        }

    }

    Coroutine fireRoutine;
    IEnumerator FireRoutine()
    {
        // �̷��� �ѹ��� �������ְ�, ������ delay�� ���°� ���ɻ� �����ϴ�
        WaitForSeconds delay = new WaitForSeconds(repeatTime);
        while (true)
        {
            // �Ѿ� ����
            Instantiate(bulletPrefab, muzzlePoint.position, muzzlePoint.rotation);
            yield return delay;
        }
    }

}
