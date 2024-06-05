using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{   //적을 생성하기 위한 클래스

    [SerializeField] private StageData stageData;       //적 생성 위치를 잡기 위한 스테이지 데이터
    [SerializeField] private float spawnTime = 2f;      //적 생성 주기, 기본 2초
    [SerializeField] private int enemyTier;  //적의 티어, 이에 따라 생성할 적 변경
    [SerializeField] private List<GameObject> enemyPrefabList;    //생성할 적 프리팹 리스트

    private GameObject enemySpawn;     //생성할 적

    [SerializeField] private GameObject background; //배경 변경을 위한 게임 오브젝트를 받을 공간

    private BackgroundScroller bg;  //배경 변경을 위한 스크립트를 받을 공간

    [Header("tier change score")]
    [SerializeField] private int tier2Score;    //이 점수를 넘으면 2티어로 상승
    [SerializeField] private int tier3Score;    //이 점수를 넘으면 3티어로 상승

    private int backgroundTier = 1;
    private int t;


    private void Awake()
    {
        //적 티어 및 생성할 적 초기화
        enemyTier = 1;
        enemySpawn = enemyPrefabList[enemyTier - 1];
        backgroundTier = 1;

        //배경 변경을 위한 스크립트 받기
        bg = background.GetComponent<BackgroundScroller>();

        //적 생성 시작
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
            
        }//티어가 3이 아닐때만 작동

        if (backgroundTier < 3)
        {
            t = PlayerStatus.instance.playerTier;
        }

        if (backgroundTier == 1)
        {

            if (t > 1 && enemyTier == 2)
            {
                bg.ChangeBackground(enemyTier);
                backgroundTier = 2;
                ClearLowTierEnemy();
            }

        }
        else if (backgroundTier == 2)
        {
            if (t > 2 && enemyTier == 3)
            {
                bg.ChangeBackground(enemyTier);
                backgroundTier = 3;
                ClearLowTierEnemy();
            }
        }


    }//update


    //적 티어 변경 함수
    public void ChangeEnemyTier(int targetTier)
    {
        if(targetTier == 2 || targetTier == 3)
        {
            enemyTier = targetTier;
            enemySpawn = enemyPrefabList[enemyTier - 1];
            print("Enemy tier changed: " + enemyTier);
            
        }
        else
        {
            print("wrong tier input");
            return;
        }
    }

    private void ClearLowTierEnemy()
    {
        GameObject[] tempArray = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = tempArray.Length - 1; i >= 0; i--)
        {
            EnemyManager e = tempArray[i].GetComponent<EnemyManager>();
            if (e.tierSelf != enemyTier)
            {
                Destroy(tempArray[i]);
            }
        }
    }


    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            float spawnPositionY = Random.Range(stageData.LimitMin.y, stageData.LimitMax.y);
            //생성할 y값 지정
            Instantiate(enemySpawn, new Vector3(stageData.LimitMax.x + 1.0f, spawnPositionY, 0.0f), Quaternion.identity);
            //적 생성
            yield return new WaitForSeconds(spawnTime);
            //spawnTime만큼 대기
        }
    }
}
