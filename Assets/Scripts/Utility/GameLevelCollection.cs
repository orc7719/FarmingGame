using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

[CreateAssetMenu(
    fileName = "GameLevelCollection.asset",
    menuName = SOArchitecture_Utility.COLLECTION_SUBMENU + "game level",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 4)]
public class SceneReferenceCollection : Collection<GameLevel>
{
    public GameLevel[] sceneList;
}
