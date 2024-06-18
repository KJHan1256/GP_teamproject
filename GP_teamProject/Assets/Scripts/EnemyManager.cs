using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{   //���� ���� ������ �����ϱ� ���� Ŭ����

    [SerializeField] private StageData stageData;    //�������� ������'
    [SerializeField] private float damage = 1;    //�� ���ݷ�
    [SerializeField] private float maxHp = 3;  //�� �ִ� ü��
    [SerializeField] private float currentHp;   //�� ���� ü��
    [SerializeField] private int scorePoint = 100;  //�� óġ�� ���޵Ǵ� ����
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float statusMultiflier = 1;    //������ ���� �����ϴ� �� ���� ���
    [SerializeField] private int statusUpScore = 5000;    //����� �����ϴ� ���� ����
    [SerializeField] private GameObject explosionPrefab;    //����� ���� ȿ��
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
        //������ ���� ���� ��� ����
        //������ ���� ������ ������
        int n = PlayerStatus.instance.score / statusUpScore;
        //���� ���� 0.1�谡 ���� ����� ������ ���� ��� ����
        float a = (float)n / 10;
        statusMultiflier += a*2;

        maxHp = maxHp * statusMultiflier;
        damage = damage * statusMultiflier;

        currentHp = maxHp;

        StartCoroutine("BackToForward");    //ȭ�� �������� ����� �ٽ� �����ʿ��� �����Ű�� �ڷ�ƾ
    }

    private IEnumerator BackToForward() 
    {
        while (true)
        {
            Vector3 pos = transform.position;
            if (pos.x <= stageData.LimitMin.x - 2.0f)    //���������� ������ ������ ����ٸ� 
            {
                pos.y = Random.Range(stageData.LimitMin.y, stageData.LimitMax.y);
                pos.x = stageData.LimitMax.x + 1.0f;
                transform.position = pos;
                //�ٽ� ȭ�� �����ʿ��� �����ϵ��� ��ġ ����

                //���� ü���� �޾Ҵٸ�
                if(currentHp != maxHp)
                {
                    //�ִ� ü���� 1/3��ŭ ü�� ȸ��
                    currentHp = Mathf.Min( currentHp+((int)maxHp / 3), maxHp);
                }
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
        spriteRenderer.color = new Color(255/255f, 0/255f ,169/255f);   //��������ũ�� ����������
        yield return new WaitForSeconds(0.05f);  //0.1�� ���
        spriteRenderer.color = originalColor; //�ٽ� ���� ������
    }

    public void OnDie()
    {
        //��� ��ġ�� ����ȿ�� ����
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        PlayerStatus.instance.score += scorePoint;
        Destroy(this.gameObject);
    }

}
