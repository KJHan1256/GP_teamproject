using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerUpMenuSpawner : MonoBehaviour
{
    //�θ� ������Ʈ ����
    [SerializeField] GameObject parentScreen;

    //�� Ƽ��� ���� ������ ���׷��̵� ����Ʈ
    [SerializeField] private List<UpgradeData> upgradeList1T = new List<UpgradeData>();
    [SerializeField] private List<UpgradeData> upgradeList2T = new List<UpgradeData>();
    [SerializeField] private List<UpgradeData> upgradeList3T = new List<UpgradeData>();
    
    //���� ���� ������ ���׷��̵� �׸�� ����Ʈ
    private List<UpgradeData> currentUpgradeList = new List<UpgradeData>();
    
    //���� �������� ���׷��̵� �׸�� ����Ʈ
    private List<UpgradeData> ownUpgradeList = new List<UpgradeData>();

    //��ȯ�� ���׷��̵� ��ư�� ���� ����Ʈ
    private List<GameObject> buttonList = new List<GameObject>();

    int a, b, c;

    //�������� �Ծ� �� ������Ʈ�� Ȱ��ȭ�Ǹ� ȣ��
    private void OnEnable()
    {

        //����Ʈ �ʱ�ȭ
        UpdateUpgradeList(PlayerStatus.instance.playerTier);
        int val = currentUpgradeList.Count;
        List<int> ints = new List<int>();

        //������ 3�� �̾ƾ� �ϴ� ��쿡�� 3�� �̱�
        if(val > 3)
        {
            for(int i = 0; i < val; i++)
            {
                ints.Add(i);
            }

         
            a = ints[Random.Range(0, ints.Count)];
            ints.Remove(a);
            b = ints[Random.Range(0, ints.Count)];
            ints.Remove(b);
            c = ints[Random.Range(0, ints.Count)];
            ints.Remove(c);

        }
        

        //������ ��ư�� ���� ����Ʈ �ʱ�ȭ
        buttonList.Clear();

        //���� ���׷��̵� �׸��� 3�� ���϶��
        if(val <= 3)
        {
            for(int i = 0;i < val; i++)
            {
                buttonList.Add(currentUpgradeList[i].upgradeButton);
            }
        }
        else
        {
            buttonList.Add(currentUpgradeList[a].upgradeButton);
            buttonList.Add(currentUpgradeList[b].upgradeButton);
            buttonList.Add(currentUpgradeList[c].upgradeButton);
        }


        //�ϼ��� ����Ʈ�� �������� ��ư ����
        for(int i = 0; i < buttonList.Count ; i++) 
        {
            GameObject btn = Instantiate(buttonList[i]);
            btn.transform.SetParent(parentScreen.transform, false);
            btn.transform.localPosition = new Vector3(0, 200 - (150 * i), 0);
        }

    }




    //���� ������ ���׷��̵� ����Ʈ�� ������Ʈ, �� ���׷��̵� �׸� ���� ���� ȣ��
    public void UpdateUpgradeList(int tier)
    {
        //������ ���� ���� ���׷��̵� ����Ʈ�� �ʱ�ȭ
        currentUpgradeList.Clear();

        //���� Ƽ� ���� ���� ����Ʈ�� ���� ����, ���� ���� ���׷��̵带 ���� ����
        List<UpgradeData> tempTierList;
        List<UpgradeData> tempOwnList = ownUpgradeList;

        switch (tier)
        {
            case 1:
                tempTierList = upgradeList1T;
                break;
            case 2:
                tempTierList = upgradeList2T;
                break;
            case 3:
                tempTierList = upgradeList3T;
                break;
            default:
                tempTierList = upgradeList1T;
                break;
        }

        //Ƽ� ����Ʈ���� ���׷��̵尡 �Ұ����� �׸� ����
        //�ε��� ������ ���� ���� �ڿ������� ������
        for(int i = tempTierList.Count - 1 ; i >= 0 ; i--)
        {
            //���� �ش� ���׷��̵尡 �ִ� ������ �ƴ϶��
            if (tempTierList[i].isUpgradable == false)
            {
                //����Ʈ���� ����
                tempTierList.RemoveAt(i);
            }
        }

        //���� ����Ʈ���� ���׷��̵� �Ұ����� �׸� ����
        for(int i = tempOwnList.Count - 1 ; i >= 0 ;i--)
        {
            if (tempOwnList[i].isUpgradable == false)
            {
                tempOwnList.RemoveAt(i);
            }
        }


        //���� ������ ���׷��̵� ����Ʈ�� �ֽ�ȭ
        currentUpgradeList.AddRange(tempTierList);
        currentUpgradeList.AddRange(tempOwnList);
        currentUpgradeList = currentUpgradeList.Distinct().ToList();
    }



}