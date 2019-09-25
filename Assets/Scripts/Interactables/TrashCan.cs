using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class TrashCan : MonoBehaviour, IInteractable
{
    SpriteRenderer rend;
    [SerializeField] GameEvent interactEvent;

    public void Interact()
    {
        PlayerItem.Instance.DestroyItem();
        interactEvent.Raise();
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
