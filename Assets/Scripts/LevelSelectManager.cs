using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LevelSelectManager : Singleton<LevelSelectManager>
{
    const string privateCode = "cB3Rm6gWdUWkj9_WpCQYowLctagzhtUEeGDlipzrRR_Q";
    const string publicCode = "5e4678bdfe232612b829d9d2";
    const string webURL = "http://dreamlo.com/lb/";

    [SerializeField] GameObject levelPreviewHolder = null;
    [SerializeField] TMP_Text levelNameText = null;
    [SerializeField] Image levelPreviewImage = null;
    [SerializeField] TMP_Text personalBestText = null;
    [SerializeField] GameObject playButton = null;
    [SerializeField] TMP_Text globalScoreText = null;
    [SerializeField] GameObject scoreboard = null;

    [SerializeField] GameLevelCollection levelList = null;

    [SerializeField] SceneReferencePlus currentlySelectedLevel = null;

    void Start()
    {
        scoreboard.SetActive(false);

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
            personalBestText.text = "Personal Best: " + newLevel.personalBest.ToString("000");

            UpdateScores(newLevel);
        }
        else
        {
            levelPreviewHolder.SetActive(false);
        }
    }

    public void SelectNewLevel(SceneReferencePlus newLevel)
    {
        scoreboard.SetActive(false);
        playButton.SetActive(newLevel != null);
        currentlySelectedLevel = newLevel;
        StopAllCoroutines();
    }

    public void LoadGameLevel()
    {
        if(currentlySelectedLevel != null)
        LoadingManager.Instance.LoadLevel(currentlySelectedLevel);
    }

    public void UpdateScores(GameLevel level)
    {
        scoreboard.SetActive(true);
        globalScoreText.text = "Global: " + level.globalBest.ToString("000");

        personalBestText.text = "Personal: "+level.personalBest.ToString("000");
        StartCoroutine(DownloadHighscore(level));
    }

    IEnumerator DownloadHighscore(GameLevel level)
    {
        string levelID = level.levelId.ToString("000");
        WWW www = new WWW(webURL + publicCode + "/pipe-get/" + levelID);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            FormatScore(www.text, level);
        }
        else
        {
            Debug.Log("Error Downloading: " + www.error);
        }
    }

    void FormatScore(string scoreStream, GameLevel level)
    {
        string[] entryInfo = scoreStream.Split(new char[] { '|' });
        if (entryInfo.Length > 1)
        {
            string score = entryInfo[1];
            globalScoreText.text = "Global: " + score;

            level.globalBest = int.Parse(score);
        }
    }


}
