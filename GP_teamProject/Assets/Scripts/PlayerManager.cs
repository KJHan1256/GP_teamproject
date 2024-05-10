using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour  //플레이어 충돌 및 기타 설정 관리용
{

    [SerializeField] private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public void TakeDamage(float damage)    //데미지 처리 함수
    {
        PlayerStatus.instance.currentHp -= damage;    //받은 데미지만큼 현재 체력 감소
        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        //체력이 0이면 사망
        if (PlayerStatus.instance.currentHp <= 0)
        {
            Debug.Log("Game Over");
        }
    }



    private IEnumerator HitColorAnimation()
    {
        spriteRenderer.color = Color.red;   //스프라이크를 빨간색으로
        yield return new WaitForSeconds(0.1f);  //0.1초 대기
        spriteRenderer.color = Color.white; //다시 원래 색으로
    }
}
