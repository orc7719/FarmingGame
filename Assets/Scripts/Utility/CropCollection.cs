using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

[CreateAssetMenu(
    fileName = "CropCollection.asset",
    menuName = SOArchitecture_Utility.COLLECTION_SUBMENU + "crop",
    order = SOArchitecture_Utility.ASSET_MENU_ORDER_COLLECTIONS + 4)]
public class CropCollection : Collection<Crop>
{
}
