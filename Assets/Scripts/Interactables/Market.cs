using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class Market : MonoBehaviour, IInteractable
{
    public GameEvent orderComplete;
    //int completedOrders = 0;
    SpriteRenderer rend;

    public CropCollection[] levelOrders;
    List<Crop> cropOrder = new List<Crop>();

    Sprite[] orderSprites;
    [SerializeField] GameEvent correctItemEvent;
    [SerializeField] GameEvent incorrectItemEvent;
    [SerializeField] GameEvent orderCompleteEvent;

    bool doExtraOrders;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        ToggleHighlight(false);
        LevelController.Instance.GetLevelSettings();

        doExtraOrders = GameManager.Settings.currentLevel.extraOrders;


        cropOrder = LevelController.Instance.GetNewOrder();

    }

    public void Interact()
    {
        if (PlayerItem.Instance.CurrentItem is Crop)
        {
            if (cropOrder.Contains((Crop)PlayerItem.Instance.CurrentItem))
            {
                cropOrder.Remove((Crop)PlayerItem.Instance.CurrentItem);
                PlayerItem.Instance.DestroyItem();

                CheckCurrentOrder();
                correctItemEvent.Raise();

                LevelController.Instance.UpdateOrderUI(cropOrder);
            }
            else
            {
                incorrectItemEvent.Raise();
            }
        }
    }

    void CheckCurrentOrder()
    {
        if (cropOrder.Count <= 0)
        {
            LevelController.Instance.completedOrders++;
            orderComplete.Raise();
            orderCompleteEvent.Raise();

            if (LevelController.Instance.completedOrders >= GameManager.Settings.currentLevel.levelOrders.Length && !doExtraOrders)
            {
                LevelController.Instance.CompleteLevel();
            }
            else
            {
                cropOrder = LevelController.Instance.GetNewOrder();
            }
        }
    }

    void UpdateMarketSprites()
    {

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
