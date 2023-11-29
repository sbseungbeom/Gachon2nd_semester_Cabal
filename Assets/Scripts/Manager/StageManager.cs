using UnityEngine;
using System.Collections.Generic;

public static class StageManager
{
    public static int CurrentStageNumber
    {
        get => PlayerPrefs.GetInt("RecentStage", 1);
    }
    public static StageData CurrentStageData { 
        get {
            var recentStageNum = CurrentStageNumber;
            var stageDatas = Resources.LoadAll<StageData>("Stage");

            foreach (var stageData in stageDatas)
            {
                if (stageData.StageNum == recentStageNum)
                {
                    return stageData;
                }
            }
            return null;
        } 
    }
}