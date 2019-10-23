using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadingManager : Singleton<LoadingManager>
{
    [SerializeField] SceneReferencePlus menuScene = null;
    [SerializeField] SceneReferencePlus uiScene = null;

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(menuScene);
    }

    public void LoadLevel(SceneReferencePlus newLevel)
    {
        SceneManager.LoadScene(uiScene);
        SceneManager.LoadScene(newLevel, LoadSceneMode.Additive);
    }
}
