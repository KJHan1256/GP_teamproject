using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{
    [SerializeField] private float attackRate = 0.3f;     //���ݺ� 
    [SerializeField] private List<GameObject> projectiles;  //���ݽ� �߻��� ����ü ������ ����Ʈ
    private int projectileIndex = 0;
    private AudioSource attackSound;
    private float projectileSize;

    

    private void Awake()
    {
        attackSound = this.GetComponent<AudioSource>();    
    }


    private void Start()
    {
        AttackSpeedUpdate(PlayerStatus.instance.attackSpeed);   //�ʱ� ���� �� ����

    }

    private void Update()
    {
        projectileSize = PlayerStatus.instance.projectileScale;
    }



    private IEnumerator TryAttack() //�߻�ü �߻縦 ���� �ڷ�ƾ �Լ�
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
            
            //�߻�ü�� ���� ��ġ�� ����

            yield return new WaitForSeconds(attackRate * PlayerStatus.instance.atkSpeedMutiplier);
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
            //����źȯ ���׷��̵� ȹ��
            case 2:
                projectileIndex = 3;
                break;
        }
    }


    //������ ���׷��̵�Ǹ� ȣ���ϴ� ������ ��� ����
    public void AttackSpeedUpdate(float atkSpeed) 
    {
        attackRate =  ( attackRate / (1f + (0.1f * atkSpeed ) ) );
    }

    public void StartFiring()   //���� ���� �Լ�
    {
        StartCoroutine("TryAttack");
    }

    public void StopFiring()    //���� ���� �Լ�
    {
        StopCoroutine("TryAttack");
    }
}
