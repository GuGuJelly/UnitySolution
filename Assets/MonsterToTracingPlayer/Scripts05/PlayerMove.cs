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
        // �Է¹����� ���� ����, ���Ͱ� 0�� ���� �������� �ʰ� ������
        if (dir == Vector3.zero)
            return;
        // ������ ���� ����. �׷��� ������׳�ƽ�� ������
        if (dir.sqrMagnitude > 1)
        {
            // ��������ȭ
            // �밢������ �� ���� �̵����� ���ϰ� �ϴ� ��ġ.
            dir.Normalize();
        }

        // �̵� ���
        // 1. �������� �̵��ϱ� position, Translate
        // 2. �������� �����ؼ� �̵��ϱ� MoveToWard
        // 3. �������� ���� �ٰ����� ������ ���� �������� �̵���  Lerp
        // ��� �ٶ���� ������ ������ǥ�踦 �������� �����̰� ���ִ� Space.World
        transform.Translate(dir * moveSpeed * Time.deltaTime, Space.World);

        // ȸ�����
        // 1. ���� �������� ���� ������ Rotate
        // 2. �������� �������� ������ RotateAround
        // 3. �������� �ٶ󺸵��� ������ LookAt
        // 4. ȸ�� �������ֱ� transform.rotation = Quarternion; ȸ���� ���ʹϾ����� ������� �ִ�
        // dir �������� ���ƺ��� �ϴ� ȸ��
        transform.rotation = Quaternion.LookRotation(dir);
        // �ƴϸ� �ؿ�ó�� ���׸Ӵ�, õõ�� ȸ����Ű�� �͵� �����ϴ� 
        // transform.rotation = Quaternion.RotateTowards(transform.rotation,Quaternion.LookRotation(dir), Time.deltaTime);
    }
}
