using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCan : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        PlayerItem.Instance.DestroyItem();
    }

    public bool isInteractable()
    {
        return true;
    }
}
