using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{   //���� �����ϱ� ���� Ŭ����

    [SerializeField] private StageData stageData;       //�� ���� ��ġ�� ��� ���� �������� ������
    [SerializeField] private float spawnTime = 2f;      //�� ���� �ֱ�, �⺻ 2��
    [SerializeField] private GameObject enemyPrefab;    //������ �� ������

    private void Awake()
    {
        StartCoroutine("SpawnEnemy");
    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            float spawnPositionY = Random.Range(stageData.LimitMin.y, stageData.LimitMax.y);
            //������ y�� ����
            Instantiate(enemyPrefab, new Vector3(stageData.LimitMax.x + 1.0f, spawnPositionY, 0.0f), Quaternion.identity);
            //�� ����
            yield return new WaitForSeconds(spawnTime);
            //spawnTime��ŭ ���
        }
    }
}
