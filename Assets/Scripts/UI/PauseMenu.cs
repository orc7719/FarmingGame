using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PauseMenu : MonoBehaviour
{
 

    public GameObject pausemenu, PauseButton;

    public void Pause()
    {
        pausemenu.SetActive(true);
        PauseButton.SetActive(false);

        Time.timeScale = 0;
    }

    public void Resume()
    {
        pausemenu.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1;
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
