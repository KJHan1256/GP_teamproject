using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class PowerUPMangaer : MonoBehaviour
{
    [SerializeField] private StageData stageData;    //스테이지 데이터'



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


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //아이템이 플레이어와 접촉하면
        if(collision.CompareTag("Player")) 
        {
            //파워업 매뉴창 띄우기
            PlayerStatus.instance.isPowerUp = true;
            //이 아이템 제거
            Destroy(this.gameObject);
        }
    }

}
