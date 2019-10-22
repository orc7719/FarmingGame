using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Game Level")]
public class GameLevel : ScriptableObject
{
    public int levelId = 0;
    public string levelName = "";
    public Sprite levelPreview = null;
    public SceneReferencePlus levelScene = null;
    public int personalBest = 0;
}
