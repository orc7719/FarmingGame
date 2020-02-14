using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Achievement")]
public class AchievementData : ScriptableObject
{
    public string achievementName;
    public string achievementDescription;
    public Sprite achievementImage;
}
