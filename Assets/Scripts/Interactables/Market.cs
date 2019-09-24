using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class Market : MonoBehaviour, IInteractable
{
    public List<Crop> cropOrder = new List<Crop>();
    public GameEvent orderComplete;

    public void Interact()
    {
        if (PlayerItem.Instance.CurrentItem is Crop)
        {
            if (cropOrder.Contains((Crop)PlayerItem.Instance.CurrentItem))
            {
                cropOrder.Remove((Crop)PlayerItem.Instance.CurrentItem);
                PlayerItem.Instance.DestroyItem();

                CheckCurrentOrder();
            }
        }
    }

    void CheckCurrentOrder()
    {
        if (cropOrder.Count <= 0)
            orderComplete.Raise();
    }

    public bool isInteractable()
    {
        return true;
    }
}
