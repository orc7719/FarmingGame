using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    public Item currentItem = null;
    public SpriteRenderer carryRend;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ScreenMouseRay();
    }

    public void ScreenMouseRay()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        if (hit.collider != null)
        {
            if(hit.collider.GetComponent<IInteractable>() != null)
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();
                interactable.Interact();
            }
        }
    }

    void PickupItem(Item newItem)
    {
        currentItem = newItem;
        carryRend.sprite = currentItem.itemSprite;
        
    }

    void DestroyCurrentItem()
    {
        if (currentItem != null)
            currentItem = null;
    }
}