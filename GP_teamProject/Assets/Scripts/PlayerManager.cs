using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour  //�÷��̾� �浹 �� ��Ÿ ���� ������
{
    private void OnTriggerEnter2D(Collider2D collision) //�浹 �߻� ��
    {
        if (collision.CompareTag("Enemy")) //���� �浹 ��
        {
            //ü�� ���� ���⿡ ����
        }
    }
}
