using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;   //���ݽ� �߻��� ����ü ������
    [SerializeField] private float attackRate = 0 / 1f;     //���� �ӵ�
 

    public void StartFiring()   //���� ���� �Լ�
    {
        StartCoroutine("TryAttack");
    }

    public void StopFiring()    //���� ���� �Լ�
    {
        StopCoroutine("TryAttack");
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
