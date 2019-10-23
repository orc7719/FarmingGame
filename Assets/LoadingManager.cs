using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


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
        //SceneManager.LoadScene(uiScene);
        //SceneManager.LoadScene(newLevel, LoadSceneMode.Additive);
    }

    IEnumerator AsyncLoadLevel(SceneReferencePlus newLevel)
    {
        AsyncOperation uiSceneOperation = SceneManager.LoadSceneAsync(uiScene);
        uiSceneOperation.allowSceneActivation = false;

        AsyncOperation newLevelOperation = SceneManager.LoadSceneAsync(newLevel, LoadSceneMode.Additive);
        newLevelOperation.allowSceneActivation = false;

        while (uiSceneOperation.progress < 0.9f && newLevelOperation.progress < 0.9f)
        {
            Debug.Log("UI Progress: " + uiSceneOperation.progress);
            Debug.Log("Level Progress: " + newLevelOperation.progress);
            yield return null;
        }

        uiSceneOperation.allowSceneActivation = true;
        newLevelOperation.allowSceneActivation = true;

        while (!uiSceneOperation.isDone && !newLevelOperation.isDone )
        {
            yield return null;
        }

        yield return new WaitForEndOfFrame();

        SceneManager.UnloadSceneAsync(menuScene);


    }

    private IEnumerator LoadScenesAsync(List<SceneReferencePlus> scenesToLoad)
    {
        Scene originalScene = SceneManager.GetActiveScene();

        List<AsyncOperation> sceneLoads = new List<AsyncOperation>();
        for (int i = 0; i < scenesToLoad.Count; ++i)
        {
            AsyncOperation sceneLoading = SceneManager.LoadSceneAsync(scenesToLoad[i], LoadSceneMode.Additive);
            sceneLoading.allowSceneActivation = false;
            sceneLoads.Add(sceneLoading);
            while (sceneLoads[i].progress < 0.9f) { yield return null; }
        }

        for (int i = 0; i < sceneLoads.Count; ++i)
        {
            sceneLoads[i].allowSceneActivation = true;
            while (!sceneLoads[i].isDone) { yield return null; }
        }

        AsyncOperation sceneUnloading = SceneManager.UnloadSceneAsync(originalScene);
        while (!sceneUnloading.isDone) { yield return null; }
    }
}
