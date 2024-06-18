using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PowerUpMenuSpawner : MonoBehaviour
{
    [SerializeField] private GameObject soundEffectObj;
    private GameObject temp;
    //부모 오브젝트 지정
    [SerializeField] GameObject parentScreen;

    //각 티어에서 등장 가능한 업그레이드 리스트
    [SerializeField] private List<UpgradeData> upgradeList1T = new List<UpgradeData>();
    [SerializeField] private List<UpgradeData> upgradeList2T = new List<UpgradeData>();
    [SerializeField] private List<UpgradeData> upgradeList3T = new List<UpgradeData>();
    
    //현재 등장 가능한 업그레이드 항목들 리스트
    private List<UpgradeData> currentUpgradeList = new List<UpgradeData>();
    
    //현재 보유중인 업그레이드 항목들 리스트
    public List<UpgradeData> ownUpgradeList = new List<UpgradeData>();

    //소환할 업그레이드 버튼을 담을 리스트
    private List<GameObject> buttonList = new List<GameObject>();

    int a, b, c;

    //아이템을 먹어 이 오브젝트가 활성화되면 호출
    private void OnEnable()
    {
        temp = Instantiate(soundEffectObj);

        print("power up activated...");

        //리스트 초기화
        UpdateUpgradeList(PlayerStatus.instance.playerTier);
        int val = currentUpgradeList.Count;
        List<int> ints = new List<int>();

        //무작위 3개 뽑아야 하는 경우에만 3개 뽑기
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
        

        //생성할 버튼을 담을 리스트 초기화
        buttonList.Clear();

        //남은 업그레이드 항목이 3개 이하라면
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

        //완성된 리스트를 바탕으로 버튼 생성
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


    //등장 가능한 업그레이드 리스트를 업데이트, 매 업그레이드 항목 추출 전에 호출
    public void UpdateUpgradeList(int tier)
    {
        print("power up initiating...");
        //지금의 등장 가능 업그레이드 리스트를 초기화
        currentUpgradeList.Clear();

        //각각 티어별 등장 가능 리스트를 담을 변수, 현재 가진 업그레이드를 담을 변수
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
        //티어별 리스트에서 업그레이드가 불가능한 항목 제거
        //인덱싱 오류를 막기 위해 뒤에서부터 리스팅
        for(int i = tempTierList.Count - 1 ; i >= 0 ; i--)
        {
            print("removing max level upgrades at tier list");
            //만약 해당 업그레이드가 최대 레밸이 아니라면
            if (tempTierList[i].currentLevel == tempTierList[i].maxLevel)
            {
                //리스트에서 제거
                tempTierList.RemoveAt(i);
            }
        }

        //소유 리스트에서 업그레이드 불가능한 항목 제거
        for(int i = tempOwnList.Count - 1 ; i >= 0 ;i--)
        {
            print("removing max level upgrades at own upgrade list");
            if (tempOwnList[i].currentLevel == tempOwnList[i].maxLevel)
            {
                tempOwnList.RemoveAt(i); 
            }
        }


        //등장 가능한 업그레이드 리스트를 최신화
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
