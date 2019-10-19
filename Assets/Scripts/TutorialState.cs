using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

[CreateAssetMenu(menuName = "Tutorial State")]
public class TutorialState : ScriptableObject
{
    public TutorialState nextStage;
    public GameEvent triggerEvent;

    

    [TextArea] public string stateText;
    public Sprite itemSprite;

    public Item targetItem;

    [Space]

    public FailState[] failStates;

    public TutorialState GetNextStage()
    {
        return nextStage;
    }

    public bool HasItem()
    {
        return (itemSprite != null);
    }

    [System.Serializable]
    public struct FailState
    {
        public GameEvent failEvent;
        public TutorialState failState;
    }
}
