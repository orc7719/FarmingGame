using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

[CreateAssetMenu(menuName = "Data/Resources")]
public class GameResources : ScriptableSingleton<GameResources>
{
    [Header("Farm Tiles")]
    public Sprite dirtTile;
    public Sprite wateredTile;
    public Sprite[] statusIcons;

    [Header("Crop Data")]
    public CropCollection allCrops;
    public Crop wheatObject;
    public Crop carrotObject;
    public Crop potatoObject;
    public Crop beetObject;

    [Header("Level Data")]
    public SceneCollection allLevels;
    public GameEvent orderCompleteEvent;

    [Header("UI Colours")]
    public Color levelLockedColour;
    public Color levelUnlockedColour;
    public Color levelCompletedColour;
    public Color levelPerfectedColour;

    [Header("Prefabs")]
    public Managers manager;
}
