using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;   //공격시 발사할 투사체 프리팹
    [SerializeField] private float attackRate = 0.3f;     //공격빈도 


    //공격속도가 등가할 때마다 공격빈도를 업데이트하기 위한 함수
    //공속이 업그레이드되면 호출하는 식으로 사용 예정
    public void AttackSpeedUpdate(float atkSpeed) 
    {
        attackRate = attackRate / (1f + (0.2f * atkSpeed ) );
    }

    public void StartFiring()   //공격 시작 함수
    {
        StartCoroutine("TryAttack");
    }

    public void StopFiring()    //공격 중지 함수
    {
        StopCoroutine("TryAttack");
    }


    private void Start()
    {
        AttackSpeedUpdate(PlayerStatus.instance.attackSpeed);   //초기 공격 빈도 설정
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
