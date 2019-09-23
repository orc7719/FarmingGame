using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Market : MonoBehaviour, IInteractable
{
    public List<Crop> cropOrder = new List<Crop>();


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

    }

    public bool isInteractable()
    {
        return true;
    }
}
