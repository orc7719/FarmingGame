using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class EventRaise : MonoBehaviour
{
    [SerializeField] GameEvent eventToRaise = null;

    public void RaiseEvent()
    {
        eventToRaise.Raise();
    }
}
