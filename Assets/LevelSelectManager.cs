using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelSelectManager : Singleton<LevelSelectManager>
{
    [SerializeField] TMP_Text levelNameText = null;
    [SerializeField] Image levelPreviewImage = null;
    [SerializeField] TMP_Text personalBestText = null;

    public void UpdateLevelDisplay(GameLevel newLevel)
    {
        Debug.Log("Updating to: " + newLevel.name);
        levelNameText.text = newLevel.levelId.ToString("00") + " - " + newLevel.levelName;
        levelPreviewImage.sprite = newLevel.levelPreview;
    }

    public void LoadGameLevel(GameLevel newLevel)
    {
        
    }
}
