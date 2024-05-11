using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScoreViewer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textScore; //점수를 표시하는 text UI를 받아오기
   
    void Awake()
    {
        textScore = GetComponent<TextMeshProUGUI>();
    }
        

    void Update()
    {
        //점수를 표시하는 text UI에 현재 점수 정보를 업데이트
        textScore.text = "Score: " + PlayerStatus.instance.score;  
    }
}
