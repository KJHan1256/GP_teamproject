using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Scriptable Object/UpgradeData")]
public class UpgradeData : ScriptableObject
{
    //���׷��̵��� �����͸� ����� ������Ʈ

    [Header("# Main Information")]
    public int maxLevel = 5;    //�� ���׷��̵��� �ִ� ��ȭ ����
    public int currentLevel = 0;    //�� ���׷��̵��� ���� ����
    public bool isUpgradable = true;    //���׷��̵� ��Ͽ� ������ �� �ִ���

    public string upgradeCode;

    //�� ���׷��̵�� ������ ���� ������Ʈ ������
    [SerializeField] private GameObject UpgradePrefeb; 

    //�� ���׷��̵��� �̸�
    public string UpgradeName;

    //�� ���׷��̵忡 ���� ����
    public string UpgradeDesc;

    [Header("# button Information")]
    public GameObject upgradeButton;

}
