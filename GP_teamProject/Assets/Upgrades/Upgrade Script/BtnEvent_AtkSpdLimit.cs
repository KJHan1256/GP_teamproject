using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnEvent_AtkSpdLimit : ResumeButton
{
    [SerializeField] private UpgradeData _upgradeData;  //���׷��̵��� ������ ����ִ� ��ũ���ͺ� ������Ʈ
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
            UpgradeData temp = _upgradeData.RelatedUpgradeData;
            _upgradeData.currentLevel += 1;
            temp.maxLevel += 1;
            //���� ������ �� ���׷��̵带 �������� �ʾҾ��ٸ�
            if (_menuSpawner.ownUpgradeList.IndexOf(_upgradeData) == -1)
            {
                //�� ���׷��̵��� �����͸� �߰�
                _menuSpawner.ownUpgradeList.Add(_upgradeData);
            }
            base.ResumeGame();
            Destroy(this.gameObject);
        }
    }

}