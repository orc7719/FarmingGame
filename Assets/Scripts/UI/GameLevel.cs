using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Level")]
public class GameLevel : ScriptableObject
{
    public SceneReference levelScene;

    public float levelTime = 180;
    public CropCollection[] levelOrders;

    public bool extraOrders = false;
    public Crop[] extraCropTypes;
    public int maxExtraOrders = 4;
    public int minExtraOrders = 2;
}
