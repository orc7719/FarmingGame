using System.Linq;
using UnityEngine;

public abstract class ScriptableSingleton<T> : ScriptableObject where T : ScriptableObject
{
    private static string debugTag = "<color=cyan>[ScriptableSingleton]</color>";

    protected static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                var type = typeof(T);
                var instances = Resources.LoadAll<T>(string.Empty);
                _instance = instances.FirstOrDefault();

                if (_instance == null)
                {
                    Debug.LogErrorFormat(debugTag + " No instance of {0} found!", type.ToString());
                }
                else if (instances.Length > 1)
                {
                    Debug.LogErrorFormat(debugTag + " Multiple instances of {0} found!", type.ToString());
                }
                else
                {
                    Debug.LogFormat(debugTag + " An instance of {0} found!", type.ToString());
                }
            }

            return _instance;
        }
    }
}