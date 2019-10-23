using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Doozy.Engine.UI;

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
            GetComponentInChildren<TMP_Text>().text = gameLevel.levelId.ToString("00");
    }

    public void OnHover()
    {
        Debug.Log("Hovered: " + name);
        LevelSelectManager.Instance.UpdateLevelDisplay(gameLevel);
    }
}
