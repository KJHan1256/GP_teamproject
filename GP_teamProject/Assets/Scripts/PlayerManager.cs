using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour  //�÷��̾� �浹 �� ��Ÿ ���� ������
{

    [SerializeField] private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public void TakeDamage(float damage)    //������ ó�� �Լ�
    {
        PlayerStatus.instance.currentHp -= damage;    //���� ��������ŭ ���� ü�� ����
        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        //ü���� 0�̸� ���
        if (PlayerStatus.instance.currentHp <= 0)
        {
            Debug.Log("Game Over");
        }
    }



    private IEnumerator HitColorAnimation()
    {
        spriteRenderer.color = Color.red;   //��������ũ�� ����������
        yield return new WaitForSeconds(0.1f);  //0.1�� ���
        spriteRenderer.color = Color.white; //�ٽ� ���� ������
    }
}
