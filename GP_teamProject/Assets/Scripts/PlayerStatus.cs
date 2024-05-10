using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] public float damage = 1f; //���ݷ�
    [SerializeField] public float maxHp = 10;  //�ִ� ü��
    [SerializeField] public float currentHp;   //���� ü��
    [SerializeField] public float attackSpeed = 1f; //���ݼӵ�

    public static PlayerStatus instance;

    private void Awake()
    {   
        if(PlayerStatus.instance == null)   //���� ������ ����̱⿡ �̱��� �������� ����
        {
            PlayerStatus.instance = this;
        }

        currentHp = maxHp;  //�ʱ� ü�� ����, ���� ü���� �ִ� ü������

    }


}
