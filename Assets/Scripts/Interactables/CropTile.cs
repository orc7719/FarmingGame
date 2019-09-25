using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class CropTile : MonoBehaviour, IInteractable
{
    [SerializeField] Seed currentCrop;
    TileState currentState;

    [SerializeField] SpriteRenderer statusRend;
    Sprite[] statusSprites;

    SpriteRenderer spriteRend;
    [SerializeField] SpriteRenderer cropRend;

    Sprite dirtSprite;
    Sprite wateredSprite;

    float plantedTime;
    [SerializeField] GameEvent waterEvent;
    [SerializeField] GameEvent plantEvent;
    [SerializeField] GameEvent grownEvent;
    [SerializeField] GameEvent harvestEvent;
    [SerializeField] GameEvent spoilEvent;

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
        statusSprites = GameManager.Resources.statusIcons;
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
        if(currentState == TileState.Planted)
        {
            if (Time.time >= plantedTime + GameManager.Settings.cropGrowTime )
            {
                currentState = TileState.Grown;
                grownEvent.Raise();
                UpdateCropSprite();
                statusRend.sprite = statusSprites[0];
            }
            
        }
        else if (currentState == TileState.Grown)
        {

            if(Time.time >= plantedTime + GameManager.Settings.cropSpoilTime)
            {
                currentState = TileState.Dead;
                statusRend.sprite = statusSprites[2];
                spoilEvent.Raise();
                UpdateCropSprite();
            }
            else if (Time.time >= plantedTime + ((GameManager.Settings.cropSpoilTime + GameManager.Settings.cropGrowTime) / 2))
            {
                statusRend.sprite = statusSprites[1];
            }
        }
    }

    void UpdateCropSprite()
    {
        switch (currentState)
        {
            case TileState.Dirt:
                spriteRend.sprite = dirtSprite;
                statusRend.sprite = null;
                cropRend.sprite = null;
                break;
            case TileState.Watered:
                spriteRend.sprite = wateredSprite;
                statusRend.sprite = null;
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