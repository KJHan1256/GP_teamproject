using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour  //플레이어 충돌 및 기타 설정 관리용
{
    private void OnTriggerEnter2D(Collider2D collision) //충돌 발생 시
    {
        if (collision.CompareTag("Enemy")) //적과 충돌 시
        {
            //체력 감소 여기에 개발
        }
    }
}
