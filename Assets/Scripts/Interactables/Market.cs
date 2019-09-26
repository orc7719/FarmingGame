using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class Market : MonoBehaviour, IInteractable
{
    public GameEvent orderComplete;
    //int completedOrders = 0;
    SpriteRenderer rend;

    [SerializeField] GameEvent correctItemEvent;
    [SerializeField] GameEvent incorrectItemEvent;
    [SerializeField] GameEvent orderCompleteEvent;

    bool doExtraOrders;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        ToggleHighlight(false);
    }

    public void Interact()
    {
        if (PlayerItem.Instance.CurrentItem is Crop)
        {
            if (LevelController.Instance.TryTurnInItem(PlayerItem.Instance.CurrentItem))
            {
               PlayerItem.Instance.DestroyItem();

                correctItemEvent.Raise();

                UIController.Instance.UpdateOrderDisplay();
            }
            else
            {
                incorrectItemEvent.Raise();
            }
        }
    }

    public bool isInteractable()
    {
        return true;
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
