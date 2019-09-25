using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using TMPro;

public class LevelController : Singleton<LevelController>
{
    public TMP_Text timer;

    bool levelPlaying = true;

    //change the time longer or shorter (convert into seconds E.G 3minuits 180 seconds)
    float gametimer = 180f;
    // Start is called before the first frame update


    float levelTimer;

    public int completedOrders = 0;
    List<CropCollection> levelOrders = new List<CropCollection>();
    List<Crop> currentOrder = new List<Crop>();

    int minCropsOrder;
    int maxCropsOrder;

    bool doExtraOrders;
    bool useAllCrops = true;

    [SerializeField] TMP_Text wheatCountText;
    [SerializeField] TMP_Text carrotCountText;
    [SerializeField] TMP_Text potatoCountText;
    [SerializeField] TMP_Text beetCountText;


    void Start()
    {
        //GetLevelSettings();
    }

    public void GetLevelSettings()
    {
        levelTimer = GameManager.Settings.currentLevel.levelTime;

        for (int i = 0; i < GameManager.Settings.currentLevel.levelOrders.Length; i++)
        {
            levelOrders.Add(GameManager.Settings.currentLevel.levelOrders[i]);
        }

        minCropsOrder = GameManager.Settings.currentLevel.minExtraOrders;
        maxCropsOrder = GameManager.Settings.currentLevel.maxExtraOrders;

        if (GameManager.Settings.currentLevel.extraCropTypes.Length > 0)
        {
            useAllCrops = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (levelPlaying)
        if (gametimer >= 0)
        {
            //this countdowns the time.
            gametimer -= Time.deltaTime;


            int seconds = (int)(gametimer % 60); //converts to seconds
            int minutes = (int)(gametimer / 60) % 60; //converts to minuits


            string timerString = string.Format("{0:0}:{1:00}", minutes, seconds);

            timer.text = timerString;
        }
        else
        {
            CompleteLevel();
        }
    }

    public void CompleteLevel()
    {
        levelPlaying = false;
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
        else
        {
            int randomCount = Random.Range(minCropsOrder, maxCropsOrder);

            for (int i = 0; i < randomCount; i++)
            {
                Debug.Log("Updating Orders 03");
                if (useAllCrops)
                    currentOrder.Add(GameManager.Resources.allCrops[Random.Range(0, GameManager.Resources.allCrops.Count)]);
                else
                {
                    currentOrder.Add(GameManager.Settings.currentLevel.extraCropTypes[Random.Range(0, GameManager.Settings.currentLevel.extraCropTypes.Length)]);
                }
            }
        }
        UpdateOrderUI();
        
        return currentOrder;
    }

    void UpdateOrderUI()
    {
        UpdateOrderUI(currentOrder);
    }

    public void UpdateOrderUI(List<Crop> updatedOrder)
    {
        Debug.Log("Updating Orders");

        int wheatCount = 0;
        int carrotCount = 0;
        int potatoCount = 0;
        int beetCount = 0;

        for (int i = 0; i < updatedOrder.Count; i++)
        {
            if(updatedOrder[i] == GameManager.Resources.wheatObject)
            {
                wheatCount++;
            }
            else if (updatedOrder[i] == GameManager.Resources.carrotObject)
            {
                carrotCount++;
            }
            else if (updatedOrder[i] == GameManager.Resources.potatoObject)
            {
                potatoCount++;
            }
            else if (updatedOrder[i] == GameManager.Resources.beetObject)
            {
                beetCount++;
            }
        }

        wheatCountText.text = wheatCount.ToString("0");
        carrotCountText.text = carrotCount.ToString("0");
        potatoCountText.text = potatoCount.ToString("0");
        beetCountText.text = beetCount.ToString("0");
    }
}
