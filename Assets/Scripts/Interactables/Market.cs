using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class Market : MonoBehaviour, IInteractable
{
    public GameEvent orderComplete = null;
    SpriteRenderer rend = null;

    [SerializeField] ParticleSystem correctParticle = null;
    [SerializeField] ParticleSystem incorrectParticle = null;

    [SerializeField] GameEvent correctItemEvent = null;
    [SerializeField] GameEvent incorrectItemEvent = null;

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
                correctParticle.Play();

                UIController.Instance.UpdateOrderDisplay();
            }
            else
            {
                incorrectParticle.Play();
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
