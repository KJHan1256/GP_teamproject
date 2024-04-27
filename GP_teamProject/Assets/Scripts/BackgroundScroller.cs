using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{//��� �������� ���� Ŭ����

    [SerializeField] private Transform target;              //����� ��� �̾����� �����̵��� �ڽ��� �տ� �� ����� ��ǥ�� �޴� �κ�
    [SerializeField] private float scrollRange = 12.8f;     //����� ũ��, �� �� �̻����� ��ǥ�� ���ϸ� ȭ���� ���� ��
    [SerializeField] private float moveSpeed = 0.02f;        //����� �̵� �ӵ�
    [SerializeField] private float moveDirection = -1;      //����� �����̴� ����, �׻� 1�� ���� ������ �ϸ� ������ ����, ����� �ݴ� ����
    
    

    void FixedUpdate()
    {
        if (transform.position.x <= scrollRange * (-1.0f))      //ȭ���� ���� ����� �ٽ� �������� ������ ������ �ڵ�
        {
            Vector3 temp = transform.position;
            temp.x = scrollRange * 2;   //ī�޶󿡼� ������ ����� ũ�� * 2 �� ��ġ�� �̵�
            transform.position = temp;
           
        }


        Vector3 pos = transform.position;
        pos.x += moveDirection * moveSpeed;
        transform.position = pos;
        //����� �����̴� �ڵ�, FixedUpdate ���̹Ƿ� ��ŸŸ�� ����


    }
}
