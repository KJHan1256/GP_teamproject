using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 inputVec;
    Rigidbody2D rigid;

    [SerializeField] private float speed = 2.0f;      //�̵��ӵ� ����, ��ũ��Ʈ �ܺο����� ���� �����ϰ� [SerializeField] ����
    [SerializeField] private StageData stageData;     //�������� ������ ������ �ޱ� ���� �ʵ�
    [SerializeField] private KeyCode keyCodeAttack = KeyCode.Space; //���ݱ�, �����̽��ٰ� �⺻
    private WeaponFire weaponFire;      //���� ��� �鿩����

    //Awake�� ������Ʈ ������ ����, ���� ���� ó�� ���۵Ǵ� �κ�
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();    //player������Ʈ�� rigidbodt2D�� ĳ��
        Application.targetFrameRate = 100;      //�������� 100���� ����
        weaponFire = GetComponent<WeaponFire>();   //���� ��� ĳ��
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
            //�׾��ٸ� ���� �Ұ�
            return;
        }

        inputVec.x = Input.GetAxisRaw("Horizontal");     //Ű���� ����Ű�� ad�� �¿� �Է¹���
        inputVec.y = Input.GetAxisRaw("Vertical");         //Ű���� ����Ű�� ws�� ����...
        
        Vector2 movement = inputVec.normalized * speed * Time.deltaTime;
        rigid.MovePosition(rigid.position + movement);


        if (Input.GetKeyDown(keyCodeAttack))    //����Ű�� ������
        {
            weaponFire.StartFiring();   //���� �ǽ�
        }
        else if (Input.GetKeyUp(keyCodeAttack)) //���� Ű�� �ȴ��� ������
        { 
            weaponFire.StopFiring();    //���� ����
        }
        
    }

    private void LateUpdate()
    {
        //�÷��̾ ȭ�� ������ ���������� ����
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
                                         Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));
    }

}
