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
    private AudioSource attackSound;


    //������ ���׷��̵�Ǹ� ȣ���ϴ� ������ ��� ����
    public void AttackSpeedUpdate(float atkSpeed) 
    {
        attackRate = attackRate / (1f + (0.1f * atkSpeed ) );
    }

    public void StartFiring()   //���� ���� �Լ�
    {
        StartCoroutine("TryAttack");
    }

    public void StopFiring()    //���� ���� �Լ�
    {
        StopCoroutine("TryAttack");
    }

    private void Awake()
    {
        attackSound = this.GetComponent<AudioSource>();    
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
            attackSound.Play();
            GameObject obj = Instantiate(projectiles[projectileIndex], transform.position, Quaternion.identity);

            if(PlayerStatus.instance.multiShorLvl > 0)
            {
                GameObject gt1 = Instantiate(projectiles[projectileIndex], transform.position, Quaternion.identity);
                Movement2D mt1 = gt1.GetComponent<Movement2D>();
                mt1.moveDiredtion = new Vector3(1, 0.5f, 0);

                if (PlayerStatus.instance.multiShorLvl > 1)
                {
                    GameObject gt2 = Instantiate(projectiles[projectileIndex], transform.position, Quaternion.identity);
                    Movement2D mt2 = gt2.GetComponent<Movement2D>();
                    mt2.moveDiredtion = new Vector3(1, -0.5f, 0);
                }
            }
            
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
