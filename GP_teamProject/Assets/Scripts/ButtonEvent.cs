using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
    //씬 변경을 위한 스크립트
{
   public void ScreenLoader(string screenName)
    {   //씬 이름을 문자열로 받아 해당 씬으로 변경
       SceneManager.LoadScene(screenName);
    }
}
