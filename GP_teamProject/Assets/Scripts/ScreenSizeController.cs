using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSizeController : MonoBehaviour
{
    [SerializeField] private int screenWidthSet;
    [SerializeField] private int screenHeightSet;
    [SerializeField] private bool isWindow = true;
    
    void Awake()
    {
        //InitialScreenSizeResoultion();

    }


    public void InitialScreenSizeResoultion()
    {
        int setWidth = screenWidthSet;
        int setHeight = screenHeightSet;

        if (isWindow)
        {
            Screen.SetResolution(setWidth, setHeight, FullScreenMode.Windowed);
        }else
        {
            Screen.SetResolution(setWidth, setHeight, FullScreenMode.FullScreenWindow);
        }
        
        

    }


    
}
