using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    const string privateCode = "cB3Rm6gWdUWkj9_WpCQYowLctagzhtUEeGDlipzrRR_Q";
    const string publicCode = "5e4678bdfe232612b829d9d2";
    const string webURL = "http://dreamlo.com/lb/";

    [SerializeField]
    GameLevelCollection levelList;

    private void Start()
    {
        LoadData();
    }

    [ContextMenu("Save Game Data")]
    public void SaveData()
    {
        for (int i = 0; i < levelList.Count; i++)
        {
            string levelTag = levelList[i].levelId.ToString("000");
            PlayerPrefs.SetInt("Level" + levelTag + "Completed", levelList[i].levelCompelted == true ? 1 : 0);
            PlayerPrefs.SetInt("Level" + levelTag + "Time", levelList[i].personalBest);
        }

        PlayerPrefs.Save();
    }

    public void SaveLevelData(GameLevel level)
    {
        string levelTag = level.levelId.ToString("000");
        PlayerPrefs.SetInt("Level" + levelTag + "Completed", level.levelCompelted == true ? 1 : 0);
        PlayerPrefs.SetInt("Level" + levelTag + "Time", level.personalBest);

        PlayerPrefs.Save();

        UploadNewScore(level, level.personalBest);
    }

    [ContextMenu("Load Game Data")]
    public void LoadData()
    {
        for (int i = 0; i < levelList.Count; i++)
        {
            string levelTag = levelList[i].levelId.ToString("000");
            levelList[i].levelCompelted = PlayerPrefs.GetInt("Level" + levelTag + "Completed", 0) == 1 ? true : false;
            levelList[i].personalBest = PlayerPrefs.GetInt("Level" + levelTag + "Time", 999);
        }
    }

    [ContextMenu("Reset Game Data")]
    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        LoadData();
    }

    public void UploadNewScore(GameLevel level, int score)
    {
        StartCoroutine(UploadHighscore(level.levelId.ToString("000"), score));
    }

    IEnumerator UploadHighscore(string levelID, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(levelID) + "/" + score);
        yield return www;
    }
}
