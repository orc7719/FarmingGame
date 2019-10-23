using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private static string debugTag = "[GameManager]";

    public static GameSettings Settings { get { return GameSettings.Instance; } }
    public static GameResources Resources { get { return GameResources.Instance; } }

    private static Managers managers;
    private static Managers Managers
    {
        get
        {
            if(managers == null)
            {
                if(managers == null)
                {
                    managers = FindObjectOfType<Managers>();
                }
                if(managers != null)
                {
                    Debug.LogFormat("{0} Managers found in the scene.", debugTag);
                }
                else
                {
                    managers = Instantiate(Resources.manager);
                    Debug.LogFormat("{0} Managers instantiated.", debugTag);
                }
            }
            return managers;
        }
    }

    public static void Setup()
    {
        managers = Managers;
    }
}
