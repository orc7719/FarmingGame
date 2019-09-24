using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPickup : MonoBehaviour, IInteractable
{
    [SerializeField] Item bucketItem;
    SpriteRenderer rend;

    public void Interact()
    {
        PlayerItem.Instance.CurrentItem = bucketItem;
    }

    public bool isInteractable()
    {
        return true;
    }

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        ToggleHighlight(false);
    }

    public void ToggleHighlight(bool newValue)
    {
        if (newValue)
        {
            rend.material.SetColor("_Color", Color.white);
        }
        else
        {
            rend.material.SetColor("_Color", Color.clear);
        }
    }
}
