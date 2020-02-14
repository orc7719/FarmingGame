using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Game Stats")]
public class GameStats : ScriptableSingleton<GameStats>
{
    public int ordersCompleted = 0;
    public int levelsCompleted = 0;
    public int cropsHarvested = 0;
    public int cropsPlanted = 0;
    public int itemsBinned = 0;
    public int waterCollected = 0;
    public int levelsFailed = 0;
}