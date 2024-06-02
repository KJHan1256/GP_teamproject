using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Upgrade", menuName = "Scriptable Object/UpgradeData")]
public class UpgradeData : ScriptableObject
{
    //업그레이드의 데이터를 담당할 오브젝트

    [Header("# Main Information")]
    public int initialMaxLvl;   //이 업그레이드의 초기 최대 강화 레벨
    public int maxLevel;    //이 업그레이드의 최대 강화 레밸, 게임중에 증가 가능
    public int currentLevel = 0;    //이 업그레이드의 현제 레벨
    

    public string upgradeCode;

    //이 업그레이드와 연관된 게임 오브젝트 프리팹
    [SerializeField] private GameObject RelatedPrefeb;
    [SerializeField] public UpgradeData RelatedUpgradeData;

    //이 업그레이드의 이름
    public string UpgradeName;

    //이 업그레이드에 대한 설명
    public string UpgradeDesc;

    [Header("# button Information")]
    public GameObject upgradeButton;

}
