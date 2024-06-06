using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnEvent_Heal : ResumeButton
{
    [SerializeField] private UpgradeData _upgradeData;  //���׷��̵��� ������ ����ִ� ��ũ���ͺ� ������Ʈ
    private int upgradeLvl;
    private int maxLvl;
    private PowerUpMenuSpawner _menuSpawner;



    private void OnEnable()
    {
        upgradeLvl = _upgradeData.currentLevel;
        maxLvl = _upgradeData.maxLevel;

        if(upgradeLvl == maxLvl)
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
            PlayerStatus.instance.currentHp = Mathf.Min(PlayerStatus.instance.currentHp+ 3, PlayerStatus.instance.maxHp);
            base.ResumeGame();
            Destroy(this.gameObject);
        }
    }

}
