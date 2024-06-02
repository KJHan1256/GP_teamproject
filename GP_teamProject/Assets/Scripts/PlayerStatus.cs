using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus instance;
    public float damage = 1f; //공격력
    public float maxHp = 10;  //최대 체력
    public float currentHp;   //현재 체력
    public float attackSpeed = 1f; //공격속도
    public int score = 0;  //점수
    public int playerTier = 1;  //플레이어 티어
    public bool isDie = false;
    public bool isPowerUp = false;
    public bool penetrateOn = false;
    public bool isWeaponUpgrade = false;


    private void Awake()
    {   
        Application.targetFrameRate = -1;

        if(PlayerStatus.instance == null)   //자주 접근할 요소이기에 싱글톤 패턴으로 구현
        {
            PlayerStatus.instance = this;
        }

        currentHp = maxHp;  //초기 체력 설정, 현재 체력을 최대 체력으로

    }


}
