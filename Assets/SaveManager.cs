using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{
    [SerializeField]
    GameLevelCollection levelList;

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
    }
}
