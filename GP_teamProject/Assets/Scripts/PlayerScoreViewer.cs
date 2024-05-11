using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerScoreViewer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textScore; //������ ǥ���ϴ� text UI�� �޾ƿ���
   
    void Awake()
    {
        textScore = GetComponent<TextMeshProUGUI>();
    }
        

    void Update()
    {
        //������ ǥ���ϴ� text UI�� ���� ���� ������ ������Ʈ
        textScore.text = "Score: " + PlayerStatus.instance.score;  
    }
}
