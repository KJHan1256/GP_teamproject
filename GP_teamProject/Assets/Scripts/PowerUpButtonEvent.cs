using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpButtonEvent : ResumeButton
{//파워업 아이템 획득 시 누르는 버튼들에 달리게 될 함수들이 작성될 스크립트

    public int pTierCounter = 0;  //티어 상승 버튼을 누른 횟수

    //티어 업 버튼을 누를 시
    public void TierUpPressed()
    {
        //티어 상승 버튼 누른 횟수 +1
        pTierCounter++;

        //플레이어의 현제 티어 받아오기
        int pTier = PlayerStatus.instance.playerTier;

        //플레이어 티어가 3보다 작다면
        if(pTier < 3)
        {
            GameObject playerTemp = GameObject.FindGameObjectWithTag("Player");
            PlayerManager pManager = playerTemp.GetComponent<PlayerManager>();
            WeaponFire wFire = playerTemp.GetComponent<WeaponFire>();

            //플레이어 티어 확인
            if(pTier == 1 && pTierCounter == 2)
            { //원래 1티어였고 티어 상승을 2번 눌렀다면 

                //플레이어 티어를 2티어로
                PlayerStatus.instance.playerTier = 2;
                pTier = 2;
                pManager.ChangePlayerSprite(pTier);
                if(PlayerStatus.instance.isWeaponUpgrade == false)
                {
                    wFire.ChangePlayerProjectile(0);
                }
 

                //티어 상승에 따른 스텟 증가
                PlayerStatus.instance.damage += 1;
                PlayerStatus.instance.attackSpeed += 1;
                PlayerStatus.instance.maxHp += 5;
                PlayerStatus.instance.currentHp = PlayerStatus.instance.maxHp;

                //버튼 누른 횟수 초기화
                pTierCounter = 0;
            }


            if (pTier == 2 && pTierCounter == 3)
            { //원래 2티어였고 티어 상승을 3번 눌렀다면 

                //플레이어 티어를 3티어로
                PlayerStatus.instance.playerTier = 3;
                pTier = 3;
                pManager.ChangePlayerSprite(pTier);
                if (PlayerStatus.instance.isWeaponUpgrade == false)
                {
                    wFire.ChangePlayerProjectile(1);
                }

                //티어 상승에 따른 스텟 증가
                PlayerStatus.instance.damage += 1;
                PlayerStatus.instance.attackSpeed += 1;
                PlayerStatus.instance.maxHp += 5;
                PlayerStatus.instance.currentHp = PlayerStatus.instance.maxHp;

                //버튼 누른 횟수 초기화
                pTierCounter = 0;
            }
        }
        else
        {
            base.ResumeGame(); //플레이어 티어가 3 이상이면 티어를 올릴 수 없으므로 종료S
        }
        
        //플레이어 티어에 따라 업그레이드 리스트 업데이트
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
