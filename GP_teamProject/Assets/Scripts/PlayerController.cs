using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 inputVec;
    Rigidbody2D rigid;

    [SerializeField] private float speed = 2.0f;      //�̵��ӵ� ����, ��ũ��Ʈ �ܺο����� ���� �����ϰ� [SerializeField] ����


    //Awake�� ������Ʈ ������ ����, ���� ���� ó�� ���۵Ǵ� �κ�
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();    //player������Ʈ�� rigidbodt2D�� ĳ��
        Application.targetFrameRate = 100;      //�������� 100���� ����
    }

    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        inputVec.x = Input.GetAxisRaw("Horizontal");     //Ű���� ����Ű�� ad�� �¿� �Է¹���
        inputVec.y = Input.GetAxisRaw("Vertical");         //Ű���� ����Ű�� ws�� ����...
        
        Vector2 movement = inputVec.normalized * speed * Time.deltaTime;
        rigid.MovePosition(rigid.position + movement);
        
    }

}
