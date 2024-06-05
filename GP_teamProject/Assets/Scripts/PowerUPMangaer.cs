using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class PowerUPMangaer : MonoBehaviour
{
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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�������� �÷��̾�� �����ϸ�
        if(collision.CompareTag("Player")) 
        {
            //�Ŀ��� �Ŵ�â ����
            PlayerStatus.instance.isPowerUp = true;
            //�� ������ ����
            Destroy(this.gameObject);
        }
    }

}
