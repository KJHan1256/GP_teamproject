using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Scriptable Object/UpgradeData")]
public class UpgradeData : ScriptableObject
{
    //���׷��̵��� �����͸� ����� ������Ʈ

    [Header("# Main Information")]
    public int initialMaxLvl;   //�� ���׷��̵��� �ʱ� �ִ� ��ȭ ����
    public int maxLevel;    //�� ���׷��̵��� �ִ� ��ȭ ����, �����߿� ���� ����
    public int currentLevel = 0;    //�� ���׷��̵��� ���� ����
    

    public string upgradeCode;

    //�� ���׷��̵�� ������ ���� ������Ʈ ������
    [SerializeField] private GameObject RelatedPrefeb;
    [SerializeField] public UpgradeData RelatedUpgradeData;

    //�� ���׷��̵��� �̸�
    public string UpgradeName;

    //�� ���׷��̵忡 ���� ����
    public string UpgradeDesc;

    [Header("# button Information")]
    public GameObject upgradeButton;

}
