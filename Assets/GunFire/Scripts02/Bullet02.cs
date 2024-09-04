using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet02 : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Rigidbody rigid;
    private void Start()
    {
        // �� ��ũ��Ʈ�� �޸� ������Ʈ�� 2�� �ڿ� ����
        Destroy(gameObject, 2f);
        
        // Rigidbody �� �̿��� ������
        // 1. �� �����ֱ� : AddForce
        // 2. �ӵ� �����ϱ� : velocity
        // 3. ȸ���� �����ֱ� : AddTorque
        // 4. ȸ���ӵ� �����ϱ� : angularVelocity
        // �չ��� ������ �������� ���ǵ常ŭ �����ش�, �ӵ��� �����ְ� �����ִ� ����
        rigid.velocity = transform.forward * moveSpeed;
    }
}
