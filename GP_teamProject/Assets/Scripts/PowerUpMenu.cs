using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMenu : MonoBehaviour
{
    [SerializeField] private GameObject PowerUpMenuCanvus;
    private PauseGame pauseCheckcomp;

    private void Start()
    {
        pauseCheckcomp = this.GetComponent<PauseGame>();
    }


    void Update()
    {
        if (pauseCheckcomp.GameIsPaused == false)
        {

            if (PlayerStatus.instance.isPowerUp == true)
            {
                Time.timeScale = 0;
                PowerUpMenuCanvus.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                PowerUpMenuCanvus.SetActive(false);
            }

        }

    }

}
    
