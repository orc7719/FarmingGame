using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Doozy.Engine;


public class LoadingManager : Singleton<LoadingManager>
{
    [SerializeField] SceneReferencePlus menuScene = null;
    [SerializeField] SceneReferencePlus uiScene = null;

    List<SceneReferencePlus> sceneList = new List<SceneReferencePlus>();

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(menuScene);
    }

    public void LoadLevel(SceneReferencePlus newLevel)
    {
        sceneList.Clear();
        sceneList.Add(uiScene);
        sceneList.Add(newLevel);

        if (sceneList.Count > 0)
            StartCoroutine(LoadScenesAsync(sceneList));
    }

    private IEnumerator LoadScenesAsync(List<SceneReferencePlus> scenesToLoad)
    {
        float startTime = Time.time;
        Scene originalScene = SceneManager.GetActiveScene();

        

        List<AsyncOperation> sceneLoads = new List<AsyncOperation>();
        for (int i = 0; i < scenesToLoad.Count; ++i)
        {
            AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(scenesToLoad[i], LoadSceneMode.Additive);
            sceneLoading.allowSceneActivation = false;
            sceneLoads.Add(sceneLoading);
            while (sceneLoads[i].progress < 0.9f) { yield return null; }
        }

        while (startTime + 1.5f > Time.time)
            yield return null;

        for (int i = 0; i < sceneLoads.Count; ++i)
        {
            sceneLoads[i].allowSceneActivation = true;
            while (!sceneLoads[i].isDone) { yield return null; }
        }

        AsyncOperation sceneUnloading = SceneManager.UnloadSceneAsync(originalScene);
        while (!sceneUnloading.isDone) { yield return null; }

        GameEventMessage.SendEvent("LevelLoaded");
    }
}
