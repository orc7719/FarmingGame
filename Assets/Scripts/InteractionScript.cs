using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class InteractionScript : MonoBehaviour
{
    public SpriteRenderer carryRend;
    IInteractable interactTarget;
    bool hasTarget = true;

    float interactDistance;

    AIPath ai;

    private void Start()
    {
        PlayerItem.Instance.DestroyItem();
        ai = GetComponent<AIPath>();
    }

    void Awake()
    {
        GetSettings();
    }

    void GetSettings()
    {
        interactDistance = GameManager.Settings.interactDistance;
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ScreenMouseRay();

        if(hasTarget)
        {
            if (ai.pathPending || !ai.reachedEndOfPath)
            {
                
            }
            else
            {
                interactTarget.Interact();
                UpdateCurrentItemRend();
                hasTarget = false;
            }
        }
    }

    public void ScreenMouseRay()
    {
        hasTarget = true;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        Vector2 moveTarget;

        if (hit.collider != null)
        {
            if(hit.collider.GetComponent<IInteractable>() != null)
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                interactTarget = interactable;
            }

            moveTarget = hit.point;
        }
        else
        {
            moveTarget = Get2DMousePosition();
        }

        ai.destination = moveTarget;
    }

    Vector2 Get2DMousePosition()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector2(pos.x, pos.y);
    }

    void UpdateCurrentItemRend()
    {
        if (PlayerItem.Instance.CurrentItem != null)
            carryRend.sprite = PlayerItem.Instance.CurrentItem.itemSprite;
        else
        {
            carryRend.sprite = null;
            Debug.Log("No Item Found");
        }
        
    }
}