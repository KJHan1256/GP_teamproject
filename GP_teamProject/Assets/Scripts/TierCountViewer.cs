using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TierCountViewer : MonoBehaviour
{
    private TextMeshProUGUI textTierCount;
    private GameObject EventSystem;
    private PowerUpButtonEvent powerUpBtnScript;
    private int tierLeft;
    private int tierCount;
    private int pTier;
    private bool isMaxTIer;

    void Awake()
    {
        textTierCount = this.GetComponent<TextMeshProUGUI>();
        EventSystem = GameObject.FindWithTag("EventSys");
        powerUpBtnScript = EventSystem.GetComponent<PowerUpButtonEvent>();
        tierLeft = 0;
        isMaxTIer = false;
    }

    private void OnEnable()
    {
        tierLeft = 0;
        tierCount = powerUpBtnScript.pTierCounter;
        pTier = PlayerStatus.instance.playerTier;
        
        if (pTier == 1)
        {
            tierLeft = 2 - tierCount;
        }
        else if (pTier == 2)
        {
            tierLeft = 3 - tierCount;
        }
        else if(pTier == 3)
        {
            isMaxTIer=true;
        }

        if(!isMaxTIer)
        {
            textTierCount.text = tierLeft.ToString() + " more to tier up";
        }
        else
        {
            textTierCount.text = "Your Tier is Max";
        }
        
    }
}
