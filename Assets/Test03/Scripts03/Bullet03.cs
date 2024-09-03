using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet03 : MonoBehaviour
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

    private void OnCollisionEnter(Collision collision)
    {
        // �ε��� ���ӿ�����Ʈ�� ���� ������Ʈ�� �ִ��� �����Ͷ�
        // collisio �� �ε��� ���� ������Ʈ ������ ����ֱ� ������
        Monster03 monster = collision.gameObject.GetComponent<Monster03>();
        if (monster != null)
        {
            // ���Ͱ� �¾����� ���� �ǰ��Լ� �ҷ��ͼ� ���� ������Ű��
            monster.TakeHit();
        }

        // �Ѿ��� ���� �ƹ��ų� �ε����� �� �����ǵ���.
        Destroy(gameObject);
    }
}
