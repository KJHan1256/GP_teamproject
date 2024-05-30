using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Scriptable Object/UpgradeData")]
public class UpgradeData : ScriptableObject
{
    //업그레이드의 데이터를 담당할 오브젝트

    [Header("# Main Information")]
    public int maxLevel = 5;    //이 업그레이드의 최대 강화 레밸
    public int currentLevel = 0;    //이 업그레이드의 현제 레벨
    public bool isUpgradable = true;    //업그레이드 목록에 등장할 수 있는지

    public string upgradeCode;

    //이 업그레이드와 연관된 게임 오브젝트 프리팹
    [SerializeField] private GameObject UpgradePrefeb; 

    //이 업그레이드의 이름
    public string UpgradeName;

    //이 업그레이드에 대한 설명
    public string UpgradeDesc;

    [Header("# button Information")]
    public GameObject upgradeButton;

}
