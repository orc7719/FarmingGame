using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using ScriptableObjectArchitecture;

public class LevelButton : MonoBehaviour
{
    [SerializeField] TMP_Text levelIdText = null;
    SceneReferencePlus gameLevel = null;

    public void SetupButton(SceneReferencePlus newLevel, int levelNum)
    {
        gameLevel = newLevel;
        levelIdText.text = levelNum.ToString(" 00");
    }

    public void LoadNewLevel()
    {
        LoadingManager.Instance.LoadLevel(gameLevel);
    }
}
