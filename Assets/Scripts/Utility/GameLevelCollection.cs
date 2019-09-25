using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Level List")]
public class SceneReferenceCollection : ScriptableObject
{
    public GameLevel[] sceneList;
}
