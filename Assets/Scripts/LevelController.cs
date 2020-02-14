using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using ScriptableObjectArchitecture;
using Doozy.Engine;
using UnityEngine.SceneManagement;

public class LevelController : Singleton<LevelController>
{
    [SerializeField] GameLevel levelData;
    public bool levelPaused;

    bool levelPlaying = true;
    [SerializeField] bool tutorial = false;
    

    //change the time longer or shorter (convert into seconds E.G 3minuits 180 seconds)
    [SerializeField] int gametimer = 180;
    // Start is called before the first frame update



    public int completedOrders = 0;
    [SerializeField] List<CropCollection> levelOrders = new List<CropCollection>();
    public List<Crop> currentOrder = new List<Crop>();

    public int GetRemainingTime()
    {
        return gametimer;
    }

    void Start()
    {
        levelPaused = false;
        Time.timeScale = 1;

        StartCoroutine(GameTimer());
        currentOrder = GetNewOrder();
    }


    IEnumerator GameTimer()
    {
        UIController.Instance.UpdateTimer(gametimer);

        while (gametimer >= 0)
        {
            if (!levelPaused)
            {
                gametimer--;
                UIController.Instance.UpdateTimer(gametimer);
                
            }
            yield return new WaitForSeconds(1f);
        }

        if (levelPlaying)
            FailLevel();
    }

    public void CompleteLevel()
    {
        levelPlaying = false;
        Time.timeScale = 0;
        GameEventMessage.SendEvent("LevelComplete");

        levelData.levelCompelted = true;
        if (GetRemainingTime() < levelData.personalBest)
            levelData.personalBest = GetRemainingTime();
        SaveManager.Instance.SaveLevelData(levelData);

        

        //UIController.Instance.ShowWinPanel();
    }

    void FailLevel()
    {
        levelPlaying = false;
        Time.timeScale = 0;
        GameEventMessage.SendEvent("LevelFailed");
        //UIController.Instance.ShowLosePanel();
    }



    public bool TryTurnInItem(Item cropItem)
    {
        Crop convertedItem = (Crop)cropItem;

        if(currentOrder.Contains(convertedItem))
        {
            currentOrder.Remove(convertedItem);

            CheckCurrentOrder();

            UIController.Instance.UpdateOrderDisplay();


            return true;
        }
        else
        {

            return false;
        }
    }

    void CheckCurrentOrder()
    {
        if(currentOrder.Count <= 0)
        {
            completedOrders++;
            GameManager.Resources.orderCompleteEvent.Raise();

            if(completedOrders >= levelOrders.Count)
            {
                if (!tutorial)
                    CompleteLevel();
            }
            else
            {
                UIController.Instance.CompleteOrder();
            }
        }
    }

    public void UpdateCurrentOrder()
    {
        currentOrder = GetNewOrder();
    }

    public List<Crop> GetNewOrder()
    {
        currentOrder.Clear();

        if (completedOrders < levelOrders.Count)
        {
            foreach (Crop cropItem in levelOrders[completedOrders].List)
            {
                currentOrder.Add(cropItem);
            }
        
        }

        UIController.Instance.UpdateOrderDisplay();

        return currentOrder;
    }
}
