using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class CropTile : MonoBehaviour, IInteractable
{
    [SerializeField] Seed currentCrop;
    TileState currentState;

    SpriteRenderer spriteRend;
    [SerializeField] SpriteRenderer cropRend;

    [SerializeField] NotificationDisplay notification;

    Sprite dirtSprite;
    Sprite wateredSprite;

    float plantedTime;
    [SerializeField] GameEvent waterEvent;
    [SerializeField] GameEvent plantEvent;
    [SerializeField] GameEvent grownEvent;
    [SerializeField] GameEvent harvestEvent;
    [SerializeField] GameEvent spoilEvent;

    [Header("Sprites")]
    [SerializeField] Sprite waterSprite;
    [SerializeField] Sprite grownSprite;
    [SerializeField] Sprite warning1Sprite;
    [SerializeField] Sprite warning2Sprite;
    [SerializeField] Sprite deadSprite;

    private void Awake()
    {
        GetResources();

        spriteRend = GetComponent<SpriteRenderer>();
        ToggleHighlight(false);
        
    }

    private void Start()
    {
        
        UpdateCropSprite();
    }

    void GetResources()
    {
        dirtSprite = GameManager.Resources.dirtTile;
        wateredSprite = GameManager.Resources.wateredTile;
    }

    public void Interact()
    {
        switch (currentState)
        {
            case TileState.Dirt:
                if (PlayerItem.Instance.CurrentItem == PlayerItem.Instance.bucketItem)
                {
                    WaterCrop();
                }
                break;
            case TileState.Watered:
                if (PlayerItem.Instance.CurrentItem is Seed && currentCrop == null)
                {
                    currentCrop = (Seed)PlayerItem.Instance.CurrentItem;
                    PlayerItem.Instance.DestroyItem();
                    currentState = TileState.Planted;
                    plantedTime = Time.time;
                    plantEvent.Raise();
                }
                break;
            case TileState.Planted:
                break;
            case TileState.Grown:
                CollectCrop();
                break;
            case TileState.Dead:
                harvestEvent.Raise();
                currentState = TileState.Dirt;
                currentCrop = null;
                break;
            default:
                break;
        }

        UpdateCropSprite();
    }

    public void WaterCrop()
    {
        currentState = TileState.Watered;
        PlayerItem.Instance.DestroyItem();
        waterEvent.Raise();
    }

    public void CollectCrop()
    {
        if (PlayerItem.Instance.ChangeItem(currentCrop.grownItem))
        {
            currentCrop = null;
            currentState = TileState.Dirt;
            harvestEvent.Raise();
        }
    }

    private void Update()
    {
        if(currentState == TileState.Dirt)
        {

        }
        else if (currentState == TileState.Planted)
        {
            if (Time.time >= plantedTime + GameManager.Settings.cropGrowTime)
            {
                currentState = TileState.Grown;
                grownEvent.Raise();
                UpdateCropSprite();
                notification.DisplayNewSprite(grownSprite);
            }

        }
        else if (currentState == TileState.Grown)
        {

            if (Time.time >= plantedTime + GameManager.Settings.cropSpoilTime)
            {
                currentState = TileState.Dead;
                notification.DisplayNewSprite(deadSprite);
                spoilEvent.Raise();
                UpdateCropSprite();
            }
            else if (Time.time >= plantedTime + ((((GameManager.Settings.cropSpoilTime - GameManager.Settings.cropGrowTime) * (2f / 3f)) + GameManager.Settings.cropGrowTime)))
            {
                notification.DisplayNewSprite(warning2Sprite);
            }
            else if (Time.time >= plantedTime + ((((GameManager.Settings.cropSpoilTime - GameManager.Settings.cropGrowTime) * (1f / 3f)) + GameManager.Settings.cropGrowTime)))
            {
                notification.DisplayNewSprite(warning1Sprite);
            }
        }
        else
        {
            notification.DisableNotification();
        }
    }

    void UpdateCropSprite()
    {
        switch (currentState)
        {
            case TileState.Dirt:
                spriteRend.sprite = dirtSprite;
                notification.DisplayNewSprite(waterSprite);
                cropRend.sprite = null;
                break;
            case TileState.Watered:
                spriteRend.sprite = wateredSprite;
                notification.DisableNotification();
                cropRend.sprite = null;
                break;
            case TileState.Planted:
                spriteRend.sprite = wateredSprite;
                cropRend.sprite = currentCrop.seedStage;
                break;
            case TileState.Grown:
                spriteRend.sprite = wateredSprite;
                cropRend.sprite = currentCrop.grownStage;
                break;
            case TileState.Dead:
                spriteRend.sprite = dirtSprite;
                cropRend.sprite = currentCrop.deadStage;
                break;
            default:
                break;
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
            spriteRend.material.SetColor("_Color", Color.white);
        }
        else
        {
            spriteRend.material.SetColor("_Color", Color.clear);
        }
    }
}

public enum TileState { Dirt, Watered, Planted, Grown, Dead }