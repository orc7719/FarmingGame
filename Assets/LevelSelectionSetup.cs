using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectionSetup : MonoBehaviour
{
    [SerializeField] Transform contentHolder;
    [SerializeField] GameObject levelSelectPrefab;

    List<GameObject> levelObjects = new List<GameObject>();

    [ContextMenu("Update Levels")]
    void UpdateLevelList()
    {
        ClearLevelList();

        for (int i = 0; i < GameManager.Resources.allLevels.sceneList.Length; i++)
        {
            GameObject newLevel = Instantiate(levelSelectPrefab, contentHolder);
            newLevel.GetComponent<LevelButton>().SetupButton(GameManager.Resources.allLevels.sceneList[i], i);
            levelObjects.Add(newLevel);
        }
    }

    void ClearLevelList()
    {
        for (int i = levelObjects.Count - 1; i >= 0; i--)
        {
            Destroy(levelObjects[i]);
        }

        levelObjects.Clear();
    }
}
