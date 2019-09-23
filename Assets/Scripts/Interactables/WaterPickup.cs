using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPickup : MonoBehaviour, IInteractable
{
    [SerializeField] Item bucketItem;

    public void Interact()
    {
        PlayerItem.Instance.CurrentItem = bucketItem;
    }

    public bool isInteractable()
    {
        return true;
    }
}
