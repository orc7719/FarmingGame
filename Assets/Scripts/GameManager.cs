using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameSettings settings;
    public static GameSettings Settings
    {
        get { return Instance.settings; }
    }

    public GameResources resources;
    public static GameResources Resources
    {
        get { return Instance.resources; }
    }

    [SerializeField] SceneReference menuScene;
    [SerializeField] SceneReference uiScene;

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(menuScene);
    }

    public void LoadLevel(SceneReference newLevel)
    {
        SceneManager.LoadScene(uiScene);
        SceneManager.LoadScene(newLevel, LoadSceneMode.Additive);
        
    }
}
