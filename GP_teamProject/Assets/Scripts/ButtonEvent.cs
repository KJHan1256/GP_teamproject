using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonEvent : MonoBehaviour
    //�� ������ ���� ��ũ��Ʈ
{
   public void ScreenLoader(string screenName)
    {   //�� �̸��� ���ڿ��� �޾� �ش� ������ ����
       SceneManager.LoadScene(screenName);
    }
}
