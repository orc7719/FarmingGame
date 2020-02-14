using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Doozy.Engine;


public class LoadingManager : Singleton<LoadingManager>
{
    [SerializeField] SceneReferencePlus menuScene = null;
    [SerializeField] SceneReferencePlus uiScene = null;
    [SerializeField] SceneReferencePlus loadingScene = null;

    List<SceneReferencePlus> scenesToLoad = new List<SceneReferencePlus>();
    List<SceneReferencePlus> loadedScenesList = new List<SceneReferencePlus>();
    SceneReferencePlus currentLevel;

    private void Start()
    {
        loadedScenesList.Add(menuScene);
    }

    public void ReturnToMenu()
    {
        scenesToLoad.Clear();
        scenesToLoad.Add(menuScene);

        currentLevel = null;

        StartCoroutine(LoadScenesAsync(scenesToLoad));
        //SceneManager.LoadScene(menuScene);
    }

    public void LoadLevel(SceneReferencePlus newLevel)
    {
        scenesToLoad.Clear();
        scenesToLoad.Add(uiScene);
        scenesToLoad.Add(newLevel);

        currentLevel = newLevel;

        if (scenesToLoad.Count > 0)
            StartCoroutine(LoadScenesAsync(scenesToLoad));
    }

    public void ReloadLevel()
    {
        Debug.LogWarning("Reloading Level");
        if (currentLevel != null)
        {
            scenesToLoad.Clear();

            scenesToLoad.Add(uiScene);
            scenesToLoad.Add(currentLevel);

            StartCoroutine(LoadScenesAsync(scenesToLoad));
        }
    }

    private IEnumerator LoadScenesAsync(List<SceneReferencePlus> scenesToLoad)
    {
        float startTime = Time.time;
        Scene originalScene = SceneManager.GetActiveScene();

        AsyncOperation loadEmptyScene = SceneManager.LoadSceneAsync(loadingScene, LoadSceneMode.Additive);
        while (!loadEmptyScene.isDone) { yield return null; }

        Debug.LogWarning("Loaded Empty Scene");

        while (startTime + 1.5f > Time.time)
            yield return null;

        Debug.LogWarning("Unloading Current Scenes");

        for (int i = 0; i < loadedScenesList.Count; ++i)
        {
            AsyncOperation sceneUnloading = SceneManager.UnloadSceneAsync(loadedScenesList[i]);
            while (!sceneUnloading.isDone) { yield return null; }
        }

        Debug.LogWarning("Finished Unloading Current Scenes");

        loadedScenesList.Clear();

        Debug.LogWarning("Loading New Scenes");

        List<AsyncOperation> sceneLoads = new List<AsyncOperation>();
        for (int i = 0; i < scenesToLoad.Count; ++i)
        {
            AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(scenesToLoad[i], LoadSceneMode.Additive);
            sceneLoading.allowSceneActivation = false;
            sceneLoads.Add(sceneLoading);
            loadedScenesList.Add(scenesToLoad[i]);
            while (sceneLoads[i].progress < 0.9f) { yield return null; }
        }

        Debug.LogWarning("Finished Loading New Scenes");

        for (int i = 0; i < sceneLoads.Count; ++i)
        {
            sceneLoads[i].allowSceneActivation = true;
            while (!sceneLoads[i].isDone) { yield return null; }
        }

        Debug.LogWarning("Activated Scenes");

        AsyncOperation unloadEmptyScene = SceneManager.UnloadSceneAsync(loadingScene);
        while (!unloadEmptyScene.isDone) { yield return null; }

        Debug.LogWarning("Unloaded Empty Scene");
        GameEventMessage.SendEvent("LevelLoaded");
    }
}
