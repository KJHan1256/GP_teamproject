using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameQuitButton : MonoBehaviour
{
    [SerializeField] private string sceneName;


   public void QuitGame()
    {
        Application.Quit(); 
    }


    public void ToMain()
    {
        SceneManager.LoadScene(sceneName);
    }

}
