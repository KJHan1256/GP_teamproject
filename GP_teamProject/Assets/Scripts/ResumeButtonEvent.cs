using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeButton : MonoBehaviour
{
    //��ư�� ������ �� �Ͻ����� ������ ���� ��ũ��Ʈ

    public void ResumeGame()
    {
        PlayerStatus.instance.isPowerUp = false;
    }
}
