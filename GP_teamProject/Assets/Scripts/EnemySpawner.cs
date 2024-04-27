using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{   //적을 생성하기 위한 클래스

    [SerializeField] private StageData stageData;       //적 생성 위치를 잡기 위한 스테이지 데이터
    [SerializeField] private float spawnTime = 2f;      //적 생성 주기, 기본 2초
    [SerializeField] private GameObject enemyPrefab;    //생성할 적 프리팹

    private void Awake()
    {
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            float spawnPositionY = Random.Range(stageData.LimitMin.y, stageData.LimitMax.y);
            //생성할 y값 지정
            Instantiate(enemyPrefab, new Vector3(stageData.LimitMax.x + 1.0f, spawnPositionY, 0.0f), Quaternion.identity);
            //적 생성
            yield return new WaitForSeconds(spawnTime);
            //spawnTime만큼 대기
        }
    }
}
