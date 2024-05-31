using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{   //���� �����ϱ� ���� Ŭ����

    [SerializeField] private StageData stageData;       //�� ���� ��ġ�� ��� ���� �������� ������
    [SerializeField] private float spawnTime = 2f;      //�� ���� �ֱ�, �⺻ 2��
    [SerializeField] private int enemyTier;  //���� Ƽ��, �̿� ���� ������ �� ����
    [SerializeField] private List<GameObject> enemyPrefabList;    //������ �� ������ ����Ʈ

    private GameObject enemySpawn;     //������ ��

    [SerializeField] private GameObject background; //��� ������ ���� ���� ������Ʈ�� ���� ����

    private BackgroundScroller bg;  //��� ������ ���� ��ũ��Ʈ�� ���� ����

    [Header("tier change score")]
    [SerializeField] private int tier2Score;    //�� ������ ������ 2Ƽ��� ���
    [SerializeField] private int tier3Score;    //�� ������ ������ 3Ƽ��� ���

    


    private void Awake()
    {
        //�� Ƽ�� �� ������ �� �ʱ�ȭ
        enemyTier = 1;
        enemySpawn = enemyPrefabList[enemyTier - 1];   

        //��� ������ ���� ��ũ��Ʈ �ޱ�
        bg = background.GetComponent<BackgroundScroller>();

        //�� ���� ����
        StartCoroutine("SpawnEnemy");
    }

    private void Update()
    {
        if(PlayerStatus.instance.playerTier != 3)
        {
            int sc = PlayerStatus.instance.score;
            if (enemyTier == 1 && sc >= tier2Score) 
            {
                ChangeEnemyTier(2);
            }
            else if(enemyTier == 2 && sc >= tier3Score)
            {
                ChangeEnemyTier(3);
            }
        }
    }


    //�� Ƽ�� ���� �Լ�
    public void ChangeEnemyTier(int targetTier)
    {
        if(targetTier == 2 || targetTier == 3)
        {
            enemyTier = targetTier;
            enemySpawn = enemyPrefabList[enemyTier - 1];
            bg.ChangeBackground(enemyTier);
            print("Enemy tier changed: " + enemyTier);
        }
        else
        {
            print("wrong tier input");
            return;
        }
    }


    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            float spawnPositionY = Random.Range(stageData.LimitMin.y, stageData.LimitMax.y);
            //������ y�� ����
            Instantiate(enemySpawn, new Vector3(stageData.LimitMax.x + 1.0f, spawnPositionY, 0.0f), Quaternion.identity);
            //�� ����
            yield return new WaitForSeconds(spawnTime);
            //spawnTime��ŭ ���
        }
    }
}
