using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBin : MonoBehaviour, IInteractable
{
    public Seed seedItem;

    public void Interact()
    {
        PlayerItem.Instance.CurrentItem = seedItem;
    }

    public bool isInteractable()
    {
        return true;
    }
}
