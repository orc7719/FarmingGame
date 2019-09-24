using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    public SpriteRenderer carryRend;

   private void Start()
    {
        PlayerItem.Instance.DestroyItem();
    }

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
                UpdateCurrentItemRend();
            }
        }
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