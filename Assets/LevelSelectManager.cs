using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelSelectManager : Singleton<LevelSelectManager>
{
    [SerializeField] GameObject levelPreviewHolder = null;
    [SerializeField] TMP_Text levelNameText = null;
    [SerializeField] Image levelPreviewImage = null;
    [SerializeField] TMP_Text personalBestText = null;
    [SerializeField] GameObject playButton = null;

    [SerializeField] SceneReferencePlus currentlySelectedLevel = null;

    void Start()
    {
        levelPreviewHolder.SetActive(false);
            playButton.SetActive(false);
    }

    public void UpdateLevelDisplay(GameLevel newLevel)
    {
        if (newLevel != null)
        {
            levelPreviewHolder.SetActive(true);
            levelNameText.text = newLevel.levelId.ToString("00") + " - " + newLevel.levelName;
            levelPreviewImage.sprite = newLevel.levelPreview;
        }
        else
        {
            levelPreviewHolder.SetActive(false);
        }
    }

    public void SelectNewLevel(SceneReferencePlus newLevel)
    {
        playButton.SetActive(newLevel != null);
        currentlySelectedLevel = newLevel;
    }

    public void LoadGameLevel()
    {
        if(currentlySelectedLevel != null)
        LoadingManager.Instance.LoadLevel(currentlySelectedLevel);
    }
}
