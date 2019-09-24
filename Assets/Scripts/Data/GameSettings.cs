using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Game Settings")]
public class GameSettings : ScriptableSingleton<GameSettings>
{
    public float cropGrowTime = 4f;
    public float cropSpoilTime = 10f;
}
