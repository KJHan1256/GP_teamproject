using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public static PlayerStatus instance;
    [SerializeField] public float damage = 1f; //공격력
    [SerializeField] public float maxHp = 10;  //최대 체력
    [SerializeField] public float currentHp;   //현재 체력
    [SerializeField] public float attackSpeed = 1f; //공격속도
    [SerializeField] public int score = 0;  //점수



    private void Awake()
    {   
        if(PlayerStatus.instance == null)   //자주 접근할 요소이기에 싱글톤 패턴으로 구현
        {
            PlayerStatus.instance = this;
        }

        currentHp = maxHp;  //초기 체력 설정, 현재 체력을 최대 체력으로

    }


}
