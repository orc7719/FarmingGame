using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class SeedBin : MonoBehaviour, IInteractable
{
    public Seed seedItem;
    SpriteRenderer rend;
    [SerializeField] SpriteRenderer binIcon;
    [SerializeField] GameEvent interactEvent;

    public void Interact()
    {
        if (PlayerItem.Instance.ChangeItem(seedItem))
        {
            interactEvent.Raise();
        }
    }

    public bool isInteractable()
    {
        return true;
    }

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        ToggleHighlight(false);

        binIcon.sprite = seedItem.grownItem.itemSprite;
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
