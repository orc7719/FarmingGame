using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using ScriptableObjectArchitecture;

public class InteractionScript : MonoBehaviour
{
    public SpriteRenderer carryRend = null;
    [SerializeField] GameObject carryObject = null;
    IInteractable interactTarget = null;
    bool hasTarget = true;

    AIPath ai = null;
    float pathWait = 0f;

    Vector2 moveTarget = Vector2.zero;
    float distanceToTarget = 0f;

    [SerializeField] Animator playerAnim = null;

   // AudioSource audioSource = null;

    [SerializeField] GameEvent clickEvent = null;
    [SerializeField] GameEvent clickInteractEvent = null;
    [SerializeField] GameObject touchParticle = null;

    private void Start()
    {
        PlayerItem.Instance.DestroyItem();
        ai = GetComponent<AIPath>();

       // audioSource = GetComponent<AudioSource>();
    }

    void Awake()
    {
        GetSettings();
    }

    void GetSettings()
    {

    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ScreenMouseRay();

        distanceToTarget = Vector2.Distance(transform.position, moveTarget);

        if(hasTarget && Time.time >= pathWait + 0.1f && distanceToTarget <= 0.1f)
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

        if (PlayerItem.Instance.CurrentItem == null)
            playerAnim.SetBool("CarryingItem", false);
        else
            playerAnim.SetBool("CarryingItem", true);
    }

    public void ScreenMouseRay()
    {
        clickEvent.Raise();

        hasTarget = true;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

        

        if (interactTarget != null)
            interactTarget.ToggleHighlight(false);

        if (hit.collider != null)
        {
            if (hit.collider.GetComponent<IInteractable>() != null)
            {
                IInteractable interactable = hit.collider.GetComponent<IInteractable>();

                moveTarget = hit.collider.ClosestPoint(transform.position);

                interactTarget = interactable;
                if (interactTarget != null)
                    interactTarget.ToggleHighlight(true);

                clickInteractEvent.Raise();
            }
            else
            {
                moveTarget = Get2DMousePosition();
                interactTarget = null;
            }

            
        }
        else
        {
            moveTarget = Get2DMousePosition();
            interactTarget = null;
        }

        ai.destination = moveTarget;
        pathWait = Time.time;

        if(!LevelController.Instance.levelPaused)
        Instantiate(touchParticle, Get2DMousePosition(), Quaternion.identity);
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
            //audioSource.PlayOneShot(PlayerItem.Instance.CurrentItem.pickupSound);
            carryObject.SetActive(true);
        }
        else
        {
            carryObject.SetActive(false);
            carryRend.sprite = null;
            Debug.Log("No Item Found");
        }
        
    }
}