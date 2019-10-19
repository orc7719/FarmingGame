using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class SeedBin : MonoBehaviour, IInteractable
{
    public Seed seedItem = null;
    SpriteRenderer rend = null;
    [SerializeField] SpriteRenderer binIcon = null;
    [SerializeField] GameEvent interactEvent = null;

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
