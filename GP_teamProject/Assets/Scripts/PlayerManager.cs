using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviour  //�÷��̾� �浹 �� ��Ÿ ���� ������
{

    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private string nextSceneName;  //���� �� �Ѿ ���� ���� �̸�


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


    private void OnDie() 
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
}
