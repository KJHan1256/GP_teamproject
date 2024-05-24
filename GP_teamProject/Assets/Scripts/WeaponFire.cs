using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab1;   //���ݽ� �߻��� ����ü ������
    [SerializeField] private GameObject projectilePrefab2;
    [SerializeField] private GameObject projectilePrefab3;
    [SerializeField] private float attackRate = 0.3f;     //���ݺ� 
    private List<GameObject> projectiles = new List<GameObject>();
    private int projectileIndex = 0;


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

        //�߻�ü ������ ��� ����Ʈ �ʱ�ȭ
        projectiles.Add(projectilePrefab1);
        projectiles.Add(projectilePrefab2);
        projectiles.Add(projectilePrefab3);
    }



    private IEnumerator TryAttack() //�߻�ü �߻縦 ���� �ڷ�ƾ �Լ�
    {
        while (true)
        {
            GameObject obj = Instantiate(projectiles[projectileIndex], transform.position, Quaternion.identity);
            //�߻�ü�� ���� ��ġ�� ����

            yield return new WaitForSeconds(attackRate);
            //attackRate ��ŭ ���
        }
    }


    //�߻��� ����ü ���� �޼ҵ�
    public void ChangePlayerProjectile(int EventCase) 
    {
        switch (EventCase)
        {
            //2Ƽ��� �±�
            case 0:
                projectileIndex = 1;
                break;
            //3Ƽ��� �±�
            case 1:
                projectileIndex = 2;
                break;
        }
    }

}
