using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Resources")]
public class GameResources : ScriptableSingleton<GameResources>
{
    [Header("Farm Tiles")]
    public Sprite dirtTile;
    public Sprite wateredTile;
    public Sprite[] statusIcons;
}
