using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Achievement")]
public class Achievement : ScriptableObject
{
    public string title;
    public string description;
    public Sprite previewImage;
    public int points;

    public int achievementValue;
    public bool isCompleted;
}