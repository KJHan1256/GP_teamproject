using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{   //���� ���� ������ �����ϱ� ���� Ŭ����

    [SerializeField] private StageData stageData;    //�������� ������'
    [SerializeField] private int damage = 1;    //�� ���ݷ�
    [SerializeField] private float maxHp = 3;  //�� �ִ� ü��
    [SerializeField] private float currentHp;   //�� ���� ü��
    [SerializeField] private int scorePoint = 100;  //�� óġ�� ���޵Ǵ� ����
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        currentHp = maxHp;
    }


    void Start()
    {
        StartCoroutine("BackToForward");    //ȭ�� �������� ����� �ٽ� �����ʿ��� �����Ű�� �ڷ�ƾ
    }

    private IEnumerator BackToForward() 
    {
        while (true)
        {
            Vector3 pos = transform.position;
            if (pos.x <= stageData.LimitMin.x - 2.0f)    //���������� ������ ������ ����ٸ� 
            {
                pos.x = stageData.LimitMax.x + 1.0f;
                transform.position = pos;
                //�ٽ� ȭ�� �����ʿ��� �����ϵ��� ��ġ ����
            }
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)     //�浹�� �߻��� ��
    {

        if (collision.CompareTag("Player Projectile")) //�÷��̾��� �߻�ü�� �浹�ߴٸ�
        {
            float pDamage = PlayerStatus.instance.damage;
            currentHp -= pDamage;    //�÷��̾��� ���ݷ¸�ŭ ���� ü�� ����
            StopCoroutine("HitColorAnimation");
            StartCoroutine("HitColorAnimation");

            //ü���� 0�̸� ���
            if (currentHp <= 0)
            {
                OnDie();
            }
        }

        else if (collision.CompareTag("Player")) //�÷��̾�� �浹�ϸ�
        {
            //�÷��̾� �޴��� Ŭ������ ������ ó�� �޼ҵ� ����
            collision.GetComponent<PlayerManager>().TakeDamage(damage);
        }

    }

    private IEnumerator HitColorAnimation()
    {
        spriteRenderer.color = Color.red;   //��������ũ�� ����������
        yield return new WaitForSeconds(0.05f);  //0.1�� ���
        spriteRenderer.color = Color.white; //�ٽ� ���� ������
    }

    public void OnDie()
    {
        PlayerStatus.instance.score += scorePoint;
        Destroy(this.gameObject);
    }

}
