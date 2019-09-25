using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    [SerializeField] TMP_Text levelIdText;
    GameLevel gameLevel;

    public void SetupButton(GameLevel newLevel, int levelNum)
    {
        gameLevel = newLevel;
        levelIdText.text = levelNum.ToString(" 00");
    }

    public void LoadNewLevel()
    {
        SceneManager.LoadScene(gameLevel.levelScene);
    }
}
