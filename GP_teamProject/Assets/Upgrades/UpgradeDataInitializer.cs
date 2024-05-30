using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeDataInitializer : MonoBehaviour
{
    [SerializeField] private List<UpgradeData> data;

    private void Awake()
    {
        int a = data.Count;

        for (int i = 0; i < a; i++) 
        {
            data[i].currentLevel = 0;
            data[i].isUpgradable = true;
        }
    }

}
