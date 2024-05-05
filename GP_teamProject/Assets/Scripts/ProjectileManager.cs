using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{   //화면을 나간 발사체가 제거되는 등, 발사체 관리를 위한 클래스

    [SerializeField] float scrollRange = 0f;    //화면의 범위

    void Start()
    {
        StartCoroutine("DisableProjetile");
        //발사체 제거를 위한 코루틴 실행
    }


    private IEnumerator DisableProjetile()  //발사체 제거를 위한 코루틴
    {
        while (true)
        {
            Vector3 proj = transform.position;
            if (proj.x > scrollRange)   //발사체가 화면 밖으로 나가면
            {
                Destroy(this.gameObject);   //발사체 제거
            }
            yield return null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)     //충돌 발생 시
    {
        if (collision.CompareTag("Enemy")) //적과 충돌했다면
        {
            Destroy(gameObject);    //제거
        }
    }

}
