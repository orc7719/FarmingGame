using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Seed")]
public class Seed : Item
{
    public Sprite seedStage;
    public Sprite grownStage;
    public Sprite deadStage;

    public Crop grownItem;
}
