using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPViewer : MonoBehaviour //슬라이더 UI를 통해 플레이어의 체력을 나타내는 스크립트
{
    [SerializeField] Slider sliderHP;   

    void Awake()
    {
        sliderHP = GetComponent<Slider>();
    }


    void Update()
    {
        //슬라이더의 값을 플레이어의 현제 체력 / 최대체력의 값으로 설정하여 체력 비율을 슬라이더 UI에 표시
        sliderHP.value = PlayerStatus.instance.currentHp / PlayerStatus.instance.maxHp;
    }
}
