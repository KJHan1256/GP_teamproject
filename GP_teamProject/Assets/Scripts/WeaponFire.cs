using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;   //���ݽ� �߻��� ����ü ������
    [SerializeField] private float attackRate = 0.3f;     //���ݺ� 


    //���ݼӵ��� ��� ������ ���ݺ󵵸� ������Ʈ�ϱ� ���� �Լ�
    //������ ���׷��̵�Ǹ� ȣ���ϴ� ������ ��� ����
    public void AttackSpeedUpdate(float atkSpeed) 
    {
        attackRate = attackRate / (1f + (0.2f * atkSpeed ) );
    }

    public void StartFiring()   //���� ���� �Լ�
    {
        StartCoroutine("TryAttack");
    }

    public void StopFiring()    //���� ���� �Լ�
    {
        StopCoroutine("TryAttack");
    }


    private void Start()
    {
        AttackSpeedUpdate(PlayerStatus.instance.attackSpeed);   //�ʱ� ���� �� ����
    }



    private IEnumerator TryAttack() //�߻�ü �߻縦 ���� �ڷ�ƾ �Լ�
    {
        while (true)
        {
            GameObject obj = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            //�߻�ü�� ���� ��ġ�� ����

            yield return new WaitForSeconds(attackRate);
            //attackRate ��ŭ ���
        }
    }

}
