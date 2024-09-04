using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster05 : MonoBehaviour
{
    // �÷��̾��� Transform�� ã���ֱ�
    [SerializeField] Transform playerTransform;
    [SerializeField] float sightDistance;
    [SerializeField] bool isDetect;
    [SerializeField] float moveSpeed;

    private void Start()
    {
        // �±׷� ã�� ���. �±� ã�⸦ ��õ�Ѵ�, Ư�� ���ӿ�����Ʈ ã��.
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        // �÷��̾��� ��ġ�� �����Դ�.
        playerTransform = playerGameObject.transform;
    }

    private void Update()
    {
        if (playerTransform != null) 
        {
            Look();
        }
        if (isDetect == true) 
        {
            Trace();
        }
    }

    private void Trace()
    {
        //MoveTowards(������ġ, ��ǥ��ġ, �̵��ӵ�*Time.deltaTime)
        // ������ �������� �̵��ص� �������. ������ ���ʹ� �÷��̾ �������� �Ĵٺ��״�
        // �׷��� ������ ������� �ص� Translate�� �ص� �������
        // �Ѵ� ���� ����� ���Ŵ�
        // transform.Translate(transform.forward*moveSpeed*Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, playerTransform.position, moveSpeed*Time.deltaTime);
    }

    public void Look()
    {
        // �÷��̾ �ִ� ��ġ(position)�� �ٶ󺸱�
        transform.LookAt(playerTransform.position);

        // ��ȯ���� �ε��� ���� Bollean
        // Raycast(������ġ, ����������, out RaycastHit(�ε�����), �Ÿ�, ���̾��ũ)
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, sightDistance)) 
        {
            // ����ĳ��Ʈ�� �ε��� ���
            // DrawRay(������ġ, ��¹������� �Ÿ��� �����ְ�, ����־��ֱ�)
            Debug.DrawRay(transform.position, transform.forward * hitInfo.distance,Color.red);
            // ����ĳ��Ʈ�� �ε��� ���ӿ�����Ʈ
            GameObject raycastHitGameObject = hitInfo.collider.gameObject;
            // ����ĳ��Ʈ�� �ε��� ���ӿ�����Ʈ�� �÷��̾�ٸ�
            if (raycastHitGameObject.tag == "Player") 
            {
                // �÷��̾ �´ٿ� üũ
                isDetect = true;
            }
            else
            {
                // �þ߰Ÿ��� �ȴ�� �׷��� üũ����
                isDetect= false;
            }
        }
        else
        {
            // ����ĳ��Ʈ�� �ε����� ���� ���
            // ������ �� �� �ִ��� ���ϱ�
            Debug.DrawRay(transform.position, transform.forward * sightDistance, Color.red);
        }
    }

    public void TakeHit()
    {
        // ���ʹ� �ǰݽÿ� �ٷ� �����ǵ���.
        Destroy(gameObject);
    }
}
