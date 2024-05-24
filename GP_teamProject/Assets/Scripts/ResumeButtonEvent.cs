using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    //버튼을 눌렀을 때 일시정지 해제를 위한 스크립트

    public void ResumeGame()
    {
        PlayerStatus.instance.isPowerUp = false;
    }
}
