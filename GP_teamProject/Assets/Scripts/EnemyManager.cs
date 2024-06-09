using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{   //적의 세부 동작을 관리하기 위한 클래스

    [SerializeField] private StageData stageData;    //스테이지 데이터'
    [SerializeField] private float damage = 1;    //적 공격력
    [SerializeField] private float maxHp = 3;  //적 최대 체력
    [SerializeField] private float currentHp;   //적 현재 체력
    [SerializeField] private int scorePoint = 100;  //적 처치시 지급되는 점수
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float statusMultiflier = 1;    //점수에 따라 증가하는 적 스텟 배수
    [SerializeField] private int statusUpScore = 5000;    //배수가 증가하는 점수 기준
    [SerializeField] private GameObject explosionPrefab;    //사망시 폭발 효과
    public Color originalColor;
    public int tierSelf;

    private void Awake()
    {
        originalColor = Color.white;
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHp = maxHp;
        spriteRenderer.color = originalColor;

    }


    void Start()
    {
        //점수에 따라 스탯 배수 결정
        //점수를 기준 점수로 나누고
        int n = PlayerStatus.instance.score / statusUpScore;
        //나눈 값의 0.1배가 최초 배수에 더해져 스탯 배수 결정
        float a = (float)n / 10;
        statusMultiflier += a*2;

        maxHp = maxHp * statusMultiflier;
        damage = damage * statusMultiflier;

        currentHp = maxHp;

        StartCoroutine("BackToForward");    //화면 왼쪽으로 벗어나면 다시 오른쪽에서 등장시키는 코루틴
    }

    private IEnumerator BackToForward() 
    {
        while (true)
        {
            Vector3 pos = transform.position;
            if (pos.x <= stageData.LimitMin.x - 2.0f)    //스테이지의 왼쪽을 완전히 벗어났다면 
            {
                pos.y = Random.Range(stageData.LimitMin.y, stageData.LimitMax.y);
                pos.x = stageData.LimitMax.x + 1.0f;
                transform.position = pos;
                //다시 화면 오른쪽에서 등장하도롣 위치 변경

                //만약 체력이 달았다면
                if(currentHp != maxHp)
                {
                    //최대 체력의 1/3만큼 체력 회복
                    currentHp = Mathf.Min( currentHp+((int)maxHp / 3), maxHp);
                }
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
        spriteRenderer.color = new Color(255/255f, 0/255f ,169/255f);   //스프라이크를 빨간색으로
        yield return new WaitForSeconds(0.05f);  //0.1초 대기
        spriteRenderer.color = originalColor; //다시 원래 색으로
    }

    public void OnDie()
    {
        //사망 위치에 폭발효과 생성
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        PlayerStatus.instance.score += scorePoint;
        Destroy(this.gameObject);
    }

}
