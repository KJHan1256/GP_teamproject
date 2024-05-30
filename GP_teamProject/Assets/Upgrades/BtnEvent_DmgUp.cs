using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnEvent_DmgUp : ResumeButton
{
    [SerializeField] private UpgradeData _upgradeData;
    private int upgradeLvl;
    private int maxLvl;

 


    private void OnEnable()
    {
        upgradeLvl = _upgradeData.currentLevel;
        maxLvl = _upgradeData.maxLevel;

        if(upgradeLvl == maxLvl)
        {
            _upgradeData.isUpgradable = false;
            gameObject.SetActive(false);
        }
        else
        {
            _upgradeData.isUpgradable = true;
        }
    }


    private void OnDisable()
    {
        Destroy(this.gameObject);
    }

    public void UpgradeSelected() 
    { 
        if(upgradeLvl != maxLvl)
        {
            _upgradeData.currentLevel += 1;
            PlayerStatus.instance.damage += 1;
            base.ResumeGame();
            Destroy(this.gameObject);
        }
    }

}
