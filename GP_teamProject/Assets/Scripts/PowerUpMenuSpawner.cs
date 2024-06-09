using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerUpMenuSpawner : MonoBehaviour
{
    [SerializeField] private GameObject soundEffectObj;
    private GameObject temp;
    //�θ� ������Ʈ ����
    [SerializeField] GameObject parentScreen;

    //�� Ƽ��� ���� ������ ���׷��̵� ����Ʈ
    [SerializeField] private List<UpgradeData> upgradeList1T = new List<UpgradeData>();
    [SerializeField] private List<UpgradeData> upgradeList2T = new List<UpgradeData>();
    [SerializeField] private List<UpgradeData> upgradeList3T = new List<UpgradeData>();
    
    //���� ���� ������ ���׷��̵� �׸�� ����Ʈ
    private List<UpgradeData> currentUpgradeList = new List<UpgradeData>();
    
    //���� �������� ���׷��̵� �׸�� ����Ʈ
    public List<UpgradeData> ownUpgradeList = new List<UpgradeData>();

    //��ȯ�� ���׷��̵� ��ư�� ���� ����Ʈ
    private List<GameObject> buttonList = new List<GameObject>();

    int a, b, c;

    //�������� �Ծ� �� ������Ʈ�� Ȱ��ȭ�Ǹ� ȣ��
    private void OnEnable()
    {
        temp = Instantiate(soundEffectObj);

        print("power up activated...");

        //����Ʈ �ʱ�ȭ
        UpdateUpgradeList(PlayerStatus.instance.playerTier);
        int val = currentUpgradeList.Count;
        List<int> ints = new List<int>();

        //������ 3�� �̾ƾ� �ϴ� ��쿡�� 3�� �̱�
        if(val > 3)
        {
            print("choosing random 3 nums...");
            for (int i = 0; i < val; i++)
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
            print("choosing left upgrades...");
            for (int i = 0;i < val; i++)
            {
                buttonList.Add(currentUpgradeList[i].upgradeButton);
            }
        }
        else
        {
            print("choosing random 3 upgrades...");
            buttonList.Add(currentUpgradeList[a].upgradeButton);
            buttonList.Add(currentUpgradeList[b].upgradeButton);
            buttonList.Add(currentUpgradeList[c].upgradeButton);
        }

        if(buttonList == null)
        {
            print("critical Erroe!: failed to get upgrade button!");
        }

        //�ϼ��� ����Ʈ�� �������� ��ư ����
        for(int i = 0; i < buttonList.Count ; i++) 
        {
            print("showing upgrades...");
            GameObject btn = Instantiate(buttonList[i]);
            btn.transform.SetParent(parentScreen.transform, false);
            btn.transform.localPosition = new Vector3(0, 250 - (170 * i), 0);
        }


    }

    private void OnDisable()
    {
        Destroy(temp);
    }


    //���� ������ ���׷��̵� ����Ʈ�� ������Ʈ, �� ���׷��̵� �׸� ���� ���� ȣ��
    public void UpdateUpgradeList(int tier)
    {
        print("power up initiating...");
        //������ ���� ���� ���׷��̵� ����Ʈ�� �ʱ�ȭ
        currentUpgradeList.Clear();

        //���� Ƽ� ���� ���� ����Ʈ�� ���� ����, ���� ���� ���׷��̵带 ���� ����
        List<UpgradeData> tempTierList;
        List<UpgradeData> tempOwnList = ownUpgradeList.ToList();

        switch (tier)
        {
            case 1:
                tempTierList = upgradeList1T.ToList();
                break;
            case 2:
                tempTierList = upgradeList2T.ToList();
                break;
            case 3:
                tempTierList = upgradeList3T.ToList();
                break;
            default:
                tempTierList = upgradeList1T.ToList();
                break;
        }
        if(tempTierList == null)
        {
            print("critical Error!: failed to get tierList");
        }
        //Ƽ� ����Ʈ���� ���׷��̵尡 �Ұ����� �׸� ����
        //�ε��� ������ ���� ���� �ڿ������� ������
        for(int i = tempTierList.Count - 1 ; i >= 0 ; i--)
        {
            print("removing max level upgrades at tier list");
            //���� �ش� ���׷��̵尡 �ִ� ������ �ƴ϶��
            if (tempTierList[i].currentLevel == tempTierList[i].maxLevel)
            {
                //����Ʈ���� ����
                tempTierList.RemoveAt(i);
            }
        }

        //���� ����Ʈ���� ���׷��̵� �Ұ����� �׸� ����
        for(int i = tempOwnList.Count - 1 ; i >= 0 ;i--)
        {
            print("removing max level upgrades at own upgrade list");
            if (tempOwnList[i].currentLevel == tempOwnList[i].maxLevel)
            {
                tempOwnList.RemoveAt(i); 
            }
        }


        //���� ������ ���׷��̵� ����Ʈ�� �ֽ�ȭ
        currentUpgradeList.AddRange(tempTierList);
        currentUpgradeList.AddRange(tempOwnList);
        currentUpgradeList = currentUpgradeList.Distinct().ToList();
        print("upgrade list setting complete");
        if(currentUpgradeList == null)
        {
            print("critical Error: failed to make upgrade list");
        }
    }



}
