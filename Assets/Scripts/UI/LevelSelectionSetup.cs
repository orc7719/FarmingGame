using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class LevelSelectionSetup : MonoBehaviour
{
    [SerializeField] Transform contentHolder = null;
    [SerializeField] GameObject levelSelectPrefab = null;

    List<GameObject> levelObjects = new List<GameObject>();

    [ContextMenu("Update Levels")]
    public void UpdateLevelList()
    {
        ClearLevelList();

        for (int i = 0; i < GameManager.Resources.allLevels.List.Count; i++)
        {
            GameObject newLevel = Instantiate(levelSelectPrefab, contentHolder);
            //newLevel.GetComponent<LevelButton>().SetupButton(GameManager.Resources.allLevels[i], i + 1);
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
