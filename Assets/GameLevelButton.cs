using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelButton : MonoBehaviour
{
    [SerializeField] GameLevel gameLevel;

    public void OnHover()
    {
        Debug.Log("Hovered: " + name);
        LevelSelectManager.Instance.UpdateLevelDisplay(gameLevel);
    }
}
