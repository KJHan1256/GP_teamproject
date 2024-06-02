using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnEvent_Penetrate : ResumeButton
{
    [SerializeField] private UpgradeData _upgradeData;  //업그레이드의 정보를 담고있는 스크립터블 오브젝트
    private int upgradeLvl;
    private int maxLvl;
    private PowerUpMenuSpawner _menuSpawner;



    private void OnEnable()
    {
        upgradeLvl = _upgradeData.currentLevel;
        maxLvl = _upgradeData.maxLevel;

        if (upgradeLvl == maxLvl)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        Destroy(this.gameObject);
    }


    public void UpgradeSelected()
    {
        if (upgradeLvl != maxLvl)
        {
            _menuSpawner = transform.parent.GetComponent<PowerUpMenuSpawner>();
            _upgradeData.currentLevel += 1;
            PlayerStatus.instance.penetrateOn = true;
            //만약 기존에 이 업그레이드를 소유하지 않았었다면
            if (_menuSpawner.ownUpgradeList.IndexOf(_upgradeData) == -1)
            {
                //이 업그레이드의 데이터를 추가
                _menuSpawner.ownUpgradeList.Add(_upgradeData);
            }
            base.ResumeGame();
            Destroy(this.gameObject);
        }
    }

}

