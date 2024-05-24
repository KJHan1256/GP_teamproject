using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour  //�÷��̾� �浹 �� ��Ÿ ���� ������
{

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private string nextSceneName;  //���� �� �Ѿ ���� ���� �̸�
    [SerializeField] private Sprite tier2Sprite;
    [SerializeField] private Sprite tier3Sprite;



    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public void TakeDamage(float damage)    //������ ó�� �Լ�
    {
        PlayerStatus.instance.currentHp -= damage;    //���� ��������ŭ ���� ü�� ����
        StopCoroutine("HitColorAnimation");
        StartCoroutine("HitColorAnimation");

        //ü���� 0�̸� ���
        if (PlayerStatus.instance.currentHp <= 0)
        {
            Debug.Log("Game Over");
            OnDie();
        }
    }


    public void OnDie()
    {
        //animator.SetTrigger("onDie");
        //��� �ִϸ��̼� ���
        Destroy(GetComponent<CapsuleCollider2D>());
        //�������� ����
        PlayerStatus.instance.isDie = true;
        OnDieEvent();
        //���¸� ������� ����
    }

    public void OnDieEvent() 
    {
        //�÷��̾� ��� �� 
        PlayerPrefs.SetInt("Score", PlayerStatus.instance.score);
        SceneManager.LoadScene(nextSceneName);  //nextSceneName�� ������ ������ �̵�
    }



    private IEnumerator HitColorAnimation()
    {
        spriteRenderer.color = Color.red;   //��������ũ�� ����������
        yield return new WaitForSeconds(0.1f);  //0.1�� ���
        spriteRenderer.color = Color.white; //�ٽ� ���� ������
    }


    //Ƽ� ���� ��������Ʈ ����
    public void ChangePlayerSprite(int tier)
    {
   
        //Ƽ� 2�� �ö��ٸ�
        if(tier == 2)
        {
            //2Ƽ�� ��������Ʈ�� ����
            spriteRenderer.sprite = tier2Sprite;
        }
        //Ƽ� 3���� �ö��ٸ�
        else if(tier == 3)
        {
            //3Ƽ�� ��������Ʈ�� ����
            spriteRenderer.sprite = tier3Sprite;
        }
    }

}
