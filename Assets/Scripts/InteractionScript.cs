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
    float pathWait;

    AudioSource audioSource;

    private void Start()
    {
        PlayerItem.Instance.DestroyItem();
        ai = GetComponent<AIPath>();

        audioSource = GetComponent<AudioSource>();
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

        if(hasTarget && Time.time >= pathWait + 0.1f)
        {
            if(ai.reachedEndOfPath)
            {
               
                if (interactTarget != null)
                {
                    interactTarget.Interact();
                    interactTarget.ToggleHighlight(false);
                }
                interactTarget = null;
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

        if (interactTarget != null)
            interactTarget.ToggleHighlight(false);

        if (hit.collider != null)
        {
            if (hit.collider.GetComponent<IInteractable>() != null)
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();

                interactTarget = interactable;
                if (interactTarget != null)
                    interactTarget.ToggleHighlight(true);
            }

            moveTarget = hit.collider.ClosestPoint(transform.position);
                //moveTarget = hit.point;

        }
        else
        {
            moveTarget = Get2DMousePosition();
        }

        ai.destination = moveTarget;
        pathWait = Time.time;
    }

    Vector2 Get2DMousePosition()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return new Vector2(pos.x, pos.y);
    }

    void UpdateCurrentItemRend()
    {
        if (PlayerItem.Instance.CurrentItem != null)
        {
            carryRend.sprite = PlayerItem.Instance.CurrentItem.itemSprite;
            audioSource.PlayOneShot(PlayerItem.Instance.CurrentItem.pickupSound);
        }
        else
        {
            carryRend.sprite = null;
            Debug.Log("No Item Found");
        }
        
    }
}