using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class AchievementManager : MonoBehaviour
{
    void OnEnable()
    {
        AddListeners();
    }

    void OnDisable()
    {
        RemoveListeners();
    }

    void AddListeners()
    {
        completeOrderEvent.AddListener(CompletedOrdersTracker);
    }

    void RemoveListeners()
    {
        completeOrderEvent.RemoveListener(CompletedOrdersTracker);
    }

    void TriggerAchievement(Achievement newAchievement)
    {
        newAchievement.isCompleted = true;
    }

    //Complete Orders
    [SerializeField] GameEvent completeOrderEvent;
    [SerializeField] Achievement[] orderAchievements;
    void CompletedOrdersTracker()
    {
        AchievementStats.Instance.completedOrders++;
        int statValue = AchievementStats.Instance.completedOrders;

        for (int i = 0; i < orderAchievements.Length; i++)
        {
            if(orderAchievements[i].isCompleted == false)
            {
                if (orderAchievements[i].achievementValue == statValue)
                    TriggerAchievement(orderAchievements[i]);
            }
        }
    }

    //Complete Levels
    [SerializeField] GameEvent completeLevelEvent;
    [SerializeField] Achievement[] levelAchievements;
    void CompletedLevelsTracker()
    {
        AchievementStats.Instance.completedLevels++;
        int statValue = AchievementStats.Instance.completedLevels;

        for (int i = 0; i < levelAchievements.Length; i++)
        {
            if (levelAchievements[i].isCompleted == false)
            {
                if (levelAchievements[i].achievementValue == statValue)
                    TriggerAchievement(levelAchievements[i]);
            }
        }
    }
}