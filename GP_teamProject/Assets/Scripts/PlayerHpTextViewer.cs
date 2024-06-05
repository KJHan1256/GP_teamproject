using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHpTextViewer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textHP; //체력을 표시할 텍스트


    void Awake()
    {
        textHP = GetComponent<TextMeshProUGUI>();
    }



    void Update()
    {
        //점수를 표시하는 text UI에 현재 점수 정보를 업데이트
        textHP.text = PlayerStatus.instance.currentHp + " / " + PlayerStatus.instance.maxHp;
    }
}
