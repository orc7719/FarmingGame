using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class EventRaise : MonoBehaviour
{
    [SerializeField] GameEvent eventToRaise;

    public void RaiseEvent()
    {
        eventToRaise.Raise();
    }
}
