using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : Singleton<UIController>
{
    [SerializeField] TMP_Text wheatCountText, carrotCountText, potatoCountText, beetCountText;
    public GameObject pausemenu, PauseButton;
    public TMP_Text timerText;

    [SerializeField] GameObject winPanel, losePanel;

    #region PauseMenu
    public void Pause()
    {
        
        pausemenu.SetActive(true);
        //PauseButton.SetActive(false);

        LevelController.Instance.levelPaused = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pausemenu.SetActive(false);
        //PauseButton.SetActive(true);

        LevelController.Instance.levelPaused = false;
        Time.timeScale = 1;
    }

    public void ReturnToMenu()
    {
        GameManager.Instance.ReturnToMenu();
    }

    #endregion

    public void UpdateTimer(int newTime)
    {
        newTime = Mathf.Clamp(newTime, 0, newTime);
        timerText.text = newTime.ToString("000");

    }

    public void UpdateOrderDisplay()
    {
        List<Crop> localOrder = LevelController.Instance.currentOrder;

        int wheatCount = 0;
        int carrotCount = 0;
        int potatoCount = 0;
        int beetCount = 0;

        for (int i = 0; i < localOrder.Count; i++)
        {
            if (localOrder[i] == GameManager.Resources.wheatObject)
            {
                wheatCount++;
            }
            else if (localOrder[i] == GameManager.Resources.carrotObject)
            {
                carrotCount++;
            }
            else if (localOrder[i] == GameManager.Resources.potatoObject)
            {
                potatoCount++;
            }
            else if (localOrder[i] == GameManager.Resources.beetObject)
            {
                beetCount++;
            }
        }

        wheatCountText.text = wheatCount.ToString("0");
        carrotCountText.text = carrotCount.ToString("0");
        potatoCountText.text = potatoCount.ToString("0");
        beetCountText.text = beetCount.ToString("0");
    }

    public void ShowWinPanel()
    {
        winPanel.SetActive(true);
    }

    public void ShowLosePanel()
    {
        losePanel.SetActive(true);
    }
}
