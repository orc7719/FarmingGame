using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Doozy.Engine.UI;
using UnityEngine.UI;

public class GameLevelButton : MonoBehaviour
{
    [SerializeField] GameLevel gameLevel;

    void Start()
    {
        if (gameLevel == null)
        {
            GetComponent<UIButton>().Interactable = false;
            GetComponentInChildren<TMP_Text>().text = "";
        }
        else
        {
            GetComponentInChildren<TMP_Text>().text = gameLevel.levelId.ToString("00");

        }
    }

    void OnEnable()
    {
        if (gameLevel)
            GetComponent<Image>().color = (gameLevel.levelCompelted == true) ? new Color(0.125f, 0.6f, 0.135f, 1f) : Color.white;
    }

    public void OnHover()
    {
        LevelSelectManager.Instance.SelectNewLevel(gameLevel.levelScene);
        LevelSelectManager.Instance.UpdateLevelDisplay(gameLevel);
    }
}
