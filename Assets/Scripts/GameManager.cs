using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    public GameSettings settings;
    public static GameSettings Settings
    {
        get { return Instance.settings; }
    }

    public GameResources resources;
    public static GameResources Resources
    {
        get { return Instance.resources; }
    }
}
