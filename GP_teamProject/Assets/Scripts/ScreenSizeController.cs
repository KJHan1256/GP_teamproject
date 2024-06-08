using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSizeController : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        ScreenSizeResoultion();

    }

    public void ScreenSizeResoultion()
    {
        int setWidth = 1920;
        int setHeight = 1080;

        Screen.SetResolution(setWidth, setHeight, true);
    }

}
