using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{
    [SerializeField] private float attackRate = 0.3f;     //공격빈도 
    [SerializeField] private List<GameObject> projectiles;  //공격시 발사할 투사체 프리팹 리스트
    private int projectileIndex = 0;
    private AudioSource attackSound;
    private float projectileSize;

    

    private void Awake()
    {
        attackSound = this.GetComponent<AudioSource>();    
    }


    private void Start()
    {
        AttackSpeedUpdate(PlayerStatus.instance.attackSpeed);   //초기 공격 빈도 설정

    }

    private void Update()
    {
        projectileSize = PlayerStatus.instance.projectileScale;
    }



    private IEnumerator TryAttack() //발사체 발사를 위한 코루틴 함수
    {
        while (true)
        {
            attackSound.Play();
            GameObject obj = Instantiate(projectiles[projectileIndex], transform.position, Quaternion.identity);
            obj.transform.localScale *= projectileSize;


            if(PlayerStatus.instance.multiShorLvl > 0)
            {
                GameObject gt1 = Instantiate(projectiles[projectileIndex], transform.position, Quaternion.identity);
                Movement2D mt1 = gt1.GetComponent<Movement2D>();
                mt1.moveDiredtion = new Vector3(1, 0.5f, 0);
                gt1.transform.localScale *= projectileSize;


                if (PlayerStatus.instance.multiShorLvl > 1)
                {
                    GameObject gt2 = Instantiate(projectiles[projectileIndex], transform.position, Quaternion.identity);
                    Movement2D mt2 = gt2.GetComponent<Movement2D>();
                    mt2.moveDiredtion = new Vector3(1, -0.5f, 0);
                    gt2.transform.localScale *= projectileSize;

                }
            }
            
            //발새체를 현제 위치에 생성

            yield return new WaitForSeconds(attackRate * PlayerStatus.instance.atkSpeedMutiplier);
            //attackRate 만큼 대기
        }
    }


    //발사할 투사체 변경 메소드
    public void ChangePlayerProjectile(int EventCase) 
    {
        switch (EventCase)
        {
            //2티어로 승급
            case 0:
                projectileIndex = 1;
                break;
            //3티어로 승급
            case 1:
                projectileIndex = 2;
                break;
            //얼음탄환 업그레이드 획득
            case 2:
                projectileIndex = 3;
                break;
        }
    }


    //공속이 업그레이드되면 호출하는 식으로 사용 예정
    public void AttackSpeedUpdate(float atkSpeed) 
    {
        attackRate =  ( attackRate / (1f + (0.1f * atkSpeed ) ) );
    }

    public void StartFiring()   //공격 시작 함수
    {
        StartCoroutine("TryAttack");
    }

    public void StopFiring()    //공격 중지 함수
    {
        StopCoroutine("TryAttack");
    }
}
