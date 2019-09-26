using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using TMPro;
using ScriptableObjectArchitecture;

public class LevelController : Singleton<LevelController>
{
    public bool levelPaused;
    [SerializeField] GameEvent orderCompleteEvent;

    bool levelPlaying = true;

    //change the time longer or shorter (convert into seconds E.G 3minuits 180 seconds)
    [SerializeField] int gametimer = 180;
    // Start is called before the first frame update



    public int completedOrders = 0;
    [SerializeField] List<CropCollection> levelOrders = new List<CropCollection>();
    public List<Crop> currentOrder = new List<Crop>();


    void Start()
    {
        StartCoroutine("GameTimer");
        currentOrder = GetNewOrder();
    }

    IEnumerator GameTimer()
    {
        UIController.Instance.UpdateTimer(gametimer);

        while (gametimer >= 0)
        {
            yield return new WaitForSeconds(1f);
            UIController.Instance.UpdateTimer(gametimer);
        }

        if (levelPlaying)
            FailLevel();
    }

    void CompleteLevel()
    {
        levelPlaying = false;
    }

    void FailLevel()
    {

    }

    public bool TryTurnInItem(Item cropItem)
    {
        Crop convertedItem = (Crop)cropItem;

        if(currentOrder.Contains(convertedItem))
        {
            currentOrder.Remove(convertedItem);

            CheckCurrentOrder();

            UIController.Instance.UpdateOrderDisplay();

            Debug.Log("CORRECT ITEM");

            return true;
        }
        else
        {
            Debug.Log("INCORRECT ITEM");

            return false;
        }
    }

    void CheckCurrentOrder()
    {
        if(currentOrder.Count <= 0)
        {
            completedOrders++;
            orderCompleteEvent.Raise();

            if(completedOrders >= levelOrders.Count)
            {
                CompleteLevel();
            }
            else
            {
                currentOrder = GetNewOrder();
            }
        }
    }

    public List<Crop> GetNewOrder()
    {
        currentOrder.Clear();

        if (completedOrders < levelOrders.Count)
        {
            Debug.Log("Updating Orders 01");
            foreach (Crop cropItem in levelOrders[completedOrders].List)
            {
                Debug.Log("Updating Orders 02");
                currentOrder.Add(cropItem);
            }
        
        }

        UIController.Instance.UpdateOrderDisplay();

        return currentOrder;
    }
}
