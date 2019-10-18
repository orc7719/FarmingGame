using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Achievement Stats")]
public class AchievementStats : ScriptableSingleton<AchievementStats>
{
    public int completedOrders = 0;
    public int completedLevels = 0;
}