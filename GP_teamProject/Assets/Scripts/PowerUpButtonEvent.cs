using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpButtonEvent : ResumeButton
{//�Ŀ��� ������ ȹ�� �� ������ ��ư�鿡 �޸��� �� �Լ����� �ۼ��� ��ũ��Ʈ

    public int pTierCounter = 0;  //Ƽ�� ��� ��ư�� ���� Ƚ��

    //Ƽ�� �� ��ư�� ���� ��
    public void TierUpPressed()
    {
        //Ƽ�� ��� ��ư ���� Ƚ�� +1
        pTierCounter++;

        //�÷��̾��� ���� Ƽ�� �޾ƿ���
        int pTier = PlayerStatus.instance.playerTier;

        //�÷��̾� Ƽ� 3���� �۴ٸ�
        if(pTier < 3)
        {
            GameObject playerTemp = GameObject.FindGameObjectWithTag("Player");
            PlayerManager pManager = playerTemp.GetComponent<PlayerManager>();
            WeaponFire wFire = playerTemp.GetComponent<WeaponFire>();

            //�÷��̾� Ƽ�� Ȯ��
            if(pTier == 1 && pTierCounter == 2)
            { //���� 1Ƽ��� Ƽ�� ����� 2�� �����ٸ� 

                //�÷��̾� Ƽ� 2Ƽ���
                PlayerStatus.instance.playerTier = 2;
                pTier = 2;
                pManager.ChangePlayerSprite(pTier);
                if(PlayerStatus.instance.isWeaponUpgrade == false)
                {
                    wFire.ChangePlayerProjectile(0);
                }
 

                //Ƽ�� ��¿� ���� ���� ����
                PlayerStatus.instance.damage += 1;
                PlayerStatus.instance.attackSpeed += 1;
                PlayerStatus.instance.maxHp += 5;
                PlayerStatus.instance.currentHp = PlayerStatus.instance.maxHp;

                //��ư ���� Ƚ�� �ʱ�ȭ
                pTierCounter = 0;
            }


            if (pTier == 2 && pTierCounter == 3)
            { //���� 2Ƽ��� Ƽ�� ����� 3�� �����ٸ� 

                //�÷��̾� Ƽ� 3Ƽ���
                PlayerStatus.instance.playerTier = 3;
                pTier = 3;
                pManager.ChangePlayerSprite(pTier);
                if (PlayerStatus.instance.isWeaponUpgrade == false)
                {
                    wFire.ChangePlayerProjectile(1);
                }

                //Ƽ�� ��¿� ���� ���� ����
                PlayerStatus.instance.damage += 1;
                PlayerStatus.instance.attackSpeed += 1;
                PlayerStatus.instance.maxHp += 5;
                PlayerStatus.instance.currentHp = PlayerStatus.instance.maxHp;

                //��ư ���� Ƚ�� �ʱ�ȭ
                pTierCounter = 0;
            }
        }
        else
        {
            base.ResumeGame(); //�÷��̾� Ƽ� 3 �̻��̸� Ƽ� �ø� �� �����Ƿ� ����S
        }
        
        //�÷��̾� Ƽ� ���� ���׷��̵� ����Ʈ ������Ʈ
        //switch(pTier)
        //{
           // case 2:

                //break;
            
            //case 3:

                //break;
        //}

        base.ResumeGame();
    }
    
    
}
