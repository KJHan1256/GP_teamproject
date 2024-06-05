using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHpTextViewer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textHP; //ü���� ǥ���� �ؽ�Ʈ


    void Awake()
    {
        textHP = GetComponent<TextMeshProUGUI>();
    }



    void Update()
    {
        //������ ǥ���ϴ� text UI�� ���� ���� ������ ������Ʈ
        textHP.text = PlayerStatus.instance.currentHp + " / " + PlayerStatus.instance.maxHp;
    }
}
