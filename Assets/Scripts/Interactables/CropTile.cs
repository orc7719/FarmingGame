using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropTile : MonoBehaviour, IInteractable
{
    [SerializeField] Seed currentCrop;
    TileState currentState;

    [SerializeField] SpriteRenderer spriteRend;

    public Sprite dirtSprite;
    public Sprite wateredSprite;

    float growthTimer;
    float spoilTimer;

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
                    growthTimer = Time.time;
                }
                break;
            case TileState.Planted:
                break;
            case TileState.Grown:
                CollectCrop();
                break;
            case TileState.Dead:
                currentState = TileState.Dirt;
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
    }

    public void CollectCrop()
    {
        if (PlayerItem.Instance.ChangeItem(currentCrop.grownItem))
        {
            currentCrop = null;
            currentState = TileState.Dirt;
        }
    }

    private void Update()
    {
        if(currentState == TileState.Planted)
        {
            if (Time.time >= growthTimer + 10)
            {
                currentState = TileState.Grown;
                spoilTimer = Time.time;
                UpdateCropSprite();
            }
            
        }
        else if (currentState == TileState.Grown)
        {
            if(Time.time >= spoilTimer + 10)
            {
                currentState = TileState.Dead;
                UpdateCropSprite();
            }
        }
    }

    void UpdateCropSprite()
    {
        switch (currentState)
        {
            case TileState.Dirt:
                spriteRend.sprite = dirtSprite;
                break;
            case TileState.Watered:
                spriteRend.sprite = wateredSprite;
                break;
            case TileState.Planted:
                spriteRend.sprite = currentCrop.seedStage;
                break;
            case TileState.Grown:
                spriteRend.sprite = currentCrop.grownStage;
                break;
            case TileState.Dead:
                spriteRend.sprite = currentCrop.deadStage;
                break;
            default:
                break;
        }
    }

    public bool isInteractable()
    {
        return true;
    }
}

public enum TileState { Dirt, Watered, Planted, Grown, Dead }