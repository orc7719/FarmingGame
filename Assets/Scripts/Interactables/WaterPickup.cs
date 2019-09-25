using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class WaterPickup : MonoBehaviour, IInteractable
{
    [SerializeField] Item bucketItem;
    [SerializeField] GameEvent interactEvent;

    public void Interact()
    {
        PlayerItem.Instance.CurrentItem = bucketItem;
        interactEvent.Raise();
    }

    public bool isInteractable()
    {
        return true;
    }

    public void ToggleHighlight(bool newValue)
    {

    }
}
