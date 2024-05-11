using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{   //적의 세부 동작을 관리하기 위한 클래스

    [SerializeField] private StageData stageData;    //스테이지 데이터'
    [SerializeField] private int damage = 1;    //적 공격력
    [SerializeField] private float maxHp = 3;  //적 최대 체력
    [SerializeField] private float currentHp;   //적 현재 체력
    [SerializeField] private int scorePoint = 100;  //적 처치시 지급되는 점수
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHp = maxHp;
    }


    void Start()
    {
        StartCoroutine("BackToForward");    //화면 왼쪽으로 벗어나면 다시 오른쪽에서 등장시키는 코루틴
    }

    private IEnumerator BackToForward() 
    {
        while (true)
        {
            Vector3 pos = transform.position;
            if (pos.x <= stageData.LimitMin.x - 2.0f)    //스테이지의 왼쪽을 완전히 벗어났다면 
            {
                pos.x = stageData.LimitMax.x + 1.0f;
                transform.position = pos;
                //다시 화면 오른쪽에서 등장하도롣 위치 변경
            }
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)     //충돌이 발생할 시
    {

        if (collision.CompareTag("Player Projectile")) //플레이어의 발사체와 충돌했다면
        {
            float pDamage = PlayerStatus.instance.damage;
            currentHp -= pDamage;    //플레이어의 공격력만큼 현재 체력 감소
            StopCoroutine("HitColorAnimation");
            StartCoroutine("HitColorAnimation");

            //체력이 0이면 사망
            if (currentHp <= 0)
            {
                OnDie();
            }
        }

        else if (collision.CompareTag("Player")) //플레이어와 충돌하면
        {
            //플레이어 메니저 클래스의 데미지 처리 메소드 실행
            collision.GetComponent<PlayerManager>().TakeDamage(damage);
        }

    }

    private IEnumerator HitColorAnimation()
    {
        spriteRenderer.color = Color.red;   //스프라이크를 빨간색으로
        yield return new WaitForSeconds(0.05f);  //0.1초 대기
        spriteRenderer.color = Color.white; //다시 원래 색으로
    }

    public void OnDie()
    {
        PlayerStatus.instance.score += scorePoint;
        Destroy(this.gameObject);
    }

}
