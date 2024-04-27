using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;   //공격시 발사할 투사체 프리팹
    [SerializeField] private float attackRate = 0 / 1f;     //공격 속도
 

    public void StartFiring()   //공격 시작 함수
    {
        StartCoroutine("TryAttack");
    }

    public void StopFiring()    //공격 중지 함수
    {
        StopCoroutine("TryAttack");
    }

    private IEnumerator TryAttack() //발사체 발사를 위한 코루틴 함수
    {
        while (true)
        {
            GameObject obj = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            //발새체를 현제 위치에 생성

            yield return new WaitForSeconds(attackRate);
            //attackRate 만큼 대기
        }
    }

}
