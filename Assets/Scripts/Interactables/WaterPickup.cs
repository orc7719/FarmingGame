using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class WaterPickup : MonoBehaviour, IInteractable
{
    [SerializeField] Item bucketItem = null;
    [SerializeField] GameEvent interactEvent = null;

    public void Interact()
    {
        if (PlayerItem.Instance.ChangeItem(bucketItem))
        {
            interactEvent.Raise();
        }
    }

    public bool isInteractable()
    {
        return true;
    }

    public void ToggleHighlight(bool newValue)
    {

    }
}
