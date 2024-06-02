using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject powerUpPref;
    [SerializeField] private StageData stageData;
    [SerializeField] private int scoreGap;
    private int scoreChecker;

    private void Start()
    {
        scoreChecker = scoreGap;
    }

    void Update()
    {
        int score = PlayerStatus.instance.score;
        if ((int)(score / scoreChecker) != 0)
        {
            scoreChecker += scoreGap;
            Instantiate(powerUpPref, new Vector3(stageData.LimitMax.x+2.0f, 0.0f ,0.0f), Quaternion.identity);
        }
    }
}
