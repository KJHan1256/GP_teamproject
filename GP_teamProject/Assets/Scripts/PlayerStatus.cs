using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus instance;
    public float damage = 1f; //���ݷ�
    public float maxHp = 10;  //�ִ� ü��
    public float currentHp;   //���� ü��
    public float attackSpeed = 1f; //���ݼӵ�
    public int score = 0;  //����
    public int playerTier = 1;  //�÷��̾� Ƽ��
    public bool isDie = false;
    public bool isPowerUp = false;
    public bool penetrateOn = false;
    public bool isWeaponUpgrade = false;


    private void Awake()
    {   
        Application.targetFrameRate = -1;

        if(PlayerStatus.instance == null)   //���� ������ ����̱⿡ �̱��� �������� ����
        {
            PlayerStatus.instance = this;
        }

        currentHp = maxHp;  //�ʱ� ü�� ����, ���� ü���� �ִ� ü������

    }


}
