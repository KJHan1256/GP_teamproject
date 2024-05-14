using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 inputVec;
    Rigidbody2D rigid;

    [SerializeField] private float speed = 2.0f;      //이동속도 설정, 스크립트 외부에서도 조절 가능하게 [SerializeField] 선언
    [SerializeField] private StageData stageData;     //스테이지 데이터 에셋을 받기 위한 필드
    [SerializeField] private KeyCode keyCodeAttack = KeyCode.Space; //공격기, 스페이스바가 기본
    private WeaponFire weaponFire;      //공격 기능 들여오기

    //Awake는 오브젝트 생성시 동작, 따라서 가장 처음 동작되는 부분
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();    //player오브젝트의 rigidbodt2D를 캐싱
        Application.targetFrameRate = 100;      //프레임을 100으로 고정
        weaponFire = GetComponent<WeaponFire>();   //공격 기능 캐슁
    }

    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerStatus.instance.isDie == true)
        {
            inputVec = Vector2.zero;
            //죽었다면 조작 불가
            return;
        }

        inputVec.x = Input.GetAxisRaw("Horizontal");     //키보드 방향키와 ad로 좌우 입력받음
        inputVec.y = Input.GetAxisRaw("Vertical");         //키보드 방향키와 ws로 상하...
        
        Vector2 movement = inputVec.normalized * speed * Time.deltaTime;
        rigid.MovePosition(rigid.position + movement);


        if (Input.GetKeyDown(keyCodeAttack))    //공격키가 눌리면
        {
            weaponFire.StartFiring();   //공격 실시
        }
        else if (Input.GetKeyUp(keyCodeAttack)) //공격 키가 안눌려 있으면
        { 
            weaponFire.StopFiring();    //공격 중지
        }
        
    }

    private void LateUpdate()
    {
        //플레이어가 화면 밖으로 못나가도록 제한
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
                                         Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));
    }

}
