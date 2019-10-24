using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doozy.Engine;
using Doozy.Engine.UI;

public class StatsManager : Singleton<StatsManager>
{
    [SerializeField] AchievementData testAchievement;

    [ContextMenu("Achievement Popup")]
    void TestAchievement()
    {
        TriggerAchievement(testAchievement);
    }

    public void TriggerAchievement(AchievementData achievement)
    {
        UIPopup popup = UIPopup.GetPopup("Achievement");

        if (popup == null)
            return;

        popup.Data.SetImagesSprites(achievement.achievementImage);
        popup.Data.SetLabelsTexts(achievement.achievementName, achievement.achievementDescription);

        popup.Show();
    }
}
