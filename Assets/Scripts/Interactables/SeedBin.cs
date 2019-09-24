using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedBin : MonoBehaviour, IInteractable
{
    public Seed seedItem;
    SpriteRenderer rend;

    public void Interact()
    {
        PlayerItem.Instance.CurrentItem = seedItem;
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
        if(newValue)
        {
            rend.material.SetColor("_Color", Color.white);
        }
        else
        {
            rend.material.SetColor("_Color", Color.clear);
        }
    }
}
