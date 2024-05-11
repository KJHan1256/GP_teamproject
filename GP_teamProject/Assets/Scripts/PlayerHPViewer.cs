using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPViewer : MonoBehaviour //�����̴� UI�� ���� �÷��̾��� ü���� ��Ÿ���� ��ũ��Ʈ
{
    [SerializeField] Slider sliderHP;   

    void Awake()
    {
        sliderHP = GetComponent<Slider>();
    }


    void Update()
    {
        //�����̴��� ���� �÷��̾��� ���� ü�� / �ִ�ü���� ������ �����Ͽ� ü�� ������ �����̴� UI�� ǥ��
        sliderHP.value = PlayerStatus.instance.currentHp / PlayerStatus.instance.maxHp;
    }
}
