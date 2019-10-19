using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
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

    [SerializeField] SceneReferencePlus menuScene = null;
    [SerializeField] SceneReferencePlus uiScene = null;

    void Start()
    {
        SceneManager.LoadScene(menuScene);
    }


    public void ReturnToMenu()
    {
        SceneManager.LoadScene(menuScene);
    }

    public void LoadLevel(SceneVariable newLevel)
    {
        SceneManager.LoadScene(uiScene);
        SceneManager.LoadScene(newLevel.Value.SceneIndex, LoadSceneMode.Additive);
    }
}
