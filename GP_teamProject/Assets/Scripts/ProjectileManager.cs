using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{   //ȭ���� ���� �߻�ü�� ���ŵǴ� ��, �߻�ü ������ ���� Ŭ����

    [SerializeField] float scrollRange = 0f;    //ȭ���� ����

    void Start()
    {
        StartCoroutine("DisableProjetile");
        //�߻�ü ���Ÿ� ���� �ڷ�ƾ ����
    }


    private IEnumerator DisableProjetile()  //�߻�ü ���Ÿ� ���� �ڷ�ƾ
    {
        while (true)
        {
            Vector3 proj = transform.position;
            if (proj.x > scrollRange)   //�߻�ü�� ȭ�� ������ ������
            {
                Destroy(this.gameObject);   //�߻�ü ����
            }
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)     //�浹 �߻� ��
    {
        if (collision.CompareTag("Enemy")) //���� �浹�ߴٸ�
        {
            Destroy(gameObject);    //����
        }
    }

}
