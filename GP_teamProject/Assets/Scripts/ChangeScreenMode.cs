using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScreenMode : MonoBehaviour
{
    [SerializeField] private int screenWidthSet;
    [SerializeField] private int screenHeightSet;
    [SerializeField] private bool isWindow = true;


    private void Start()
    {
        if (PlayerPrefs.HasKey("Width") && PlayerPrefs.HasKey("Height") && PlayerPrefs.HasKey("IsWindow"))
        {
            LoadWindoeData();
        }
    }


    public void ChangeScreen()
    {
        if (isWindow)
        {
            ToFullScreen();
            SaveWindoeData();
            print("now fullscreen");
        }
        else
        {
            ToWindow();
            SaveWindoeData();
            print("now window");
        }

    }


    public void ToFullScreen()
    {
        int setWidth = screenWidthSet;
        int setHeight = screenHeightSet;
        isWindow = false;
        Screen.SetResolution(setWidth, setHeight, FullScreenMode.FullScreenWindow);
    }


    public void ToWindow()
    {
        int setWidth = screenWidthSet;
        int setHeight = screenHeightSet;
        isWindow = true;
        Screen.SetResolution(setWidth, setHeight, FullScreenMode.Windowed);
    }

    public void SaveWindoeData()
    {
        PlayerPrefs.SetInt("Width", screenWidthSet);
        PlayerPrefs.SetInt("Height", screenHeightSet);
        int a;
        if (isWindow)
        {
            a = 1;
        }
        else { a = 0; }
        print(a);
        PlayerPrefs.SetInt("IsWindow", a);

        print("screen data saved");
    }

    public void LoadWindoeData()
    {
        screenWidthSet = PlayerPrefs.GetInt("Width");
        screenHeightSet = PlayerPrefs.GetInt("Height");
        int b = PlayerPrefs.GetInt("IsWindow");
        print(b);
        if (b == 1)
        {
            isWindow = true;
            print("windowmode: window");
        }
        else 
        { 
            isWindow = false;
            print("windowmode: fullscreen");
        }

        print("screen data loaded");
    }


}
