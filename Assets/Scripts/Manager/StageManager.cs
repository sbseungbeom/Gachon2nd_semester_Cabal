using UnityEngine;
using System.Collections.Generic;

public static class StageManager
{
    private static readonly Dictionary<int, StageData> cache = new();

    public static int CurrentStageNumber
    {
        get => PlayerPrefs.GetInt("RecentStage", 1);
    }
    public static StageData CurrentStageData { 
        get {
            var recentStageNum = CurrentStageNumber;
            if(cache.ContainsKey(recentStageNum))
            {
                return cache[recentStageNum];
            }

            var stageDatas = Resources.LoadAll<StageData>("Stage");

            foreach (var stageData in stageDatas)
            {
                if (stageData.StageNum == recentStageNum)
                {
                    cache[recentStageNum] = stageData;
                    return stageData;
                }
            }
            return null;
        } 
    }
}