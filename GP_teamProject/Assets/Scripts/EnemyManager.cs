using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{   //���� ���� ������ �����ϱ� ���� Ŭ����

    [SerializeField] private StageData stageData;    //�������� ������'
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
        if(collision.CompareTag("Player Projectile")) //�÷��̾��� �߻�ü�� �浹�ߴٸ�
        {
            Destroy(gameObject);    //����
        }



    }

}
