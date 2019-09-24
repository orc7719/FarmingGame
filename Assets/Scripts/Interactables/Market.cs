using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class Market : MonoBehaviour, IInteractable
{
    public GameEvent orderComplete;
    int completedOrders = 0;
    SpriteRenderer rend;

    public CropCollection[] levelOrders;
    public List<Crop> cropOrder = new List<Crop>();

    Sprite[] orderSprites;

    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        ToggleHighlight(false);

        GetNewOrder();
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
            }
        }
    }

    void CheckCurrentOrder()
    {
        if (cropOrder.Count <= 0)
        {
            completedOrders++;
            orderComplete.Raise();
            GetNewOrder();
        }
    }

    void GetNewOrder()
    {
        cropOrder.Clear();

        if(completedOrders < levelOrders.Length)
        {
            foreach (Crop cropItem in levelOrders[completedOrders].List)
            {
                cropOrder.Add(cropItem);
            }
        }
        else
        {
            //Random Order
            int randomCount = Random.Range(2, 5);

            for (int i = 0; i < randomCount; i++)
            {
                cropOrder.Add(GameManager.Resources.allCrops[Random.Range(0, GameManager.Resources.allCrops.Count)]);
            }
        }

        UpdateMarketSprites();
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
