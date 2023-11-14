using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public static int score;

    private void Awake()
    {
        score = 0;
    }

    public void UpdateRanking(int score)
    {
        List<int> NewRank = new ();
        if(PlayerPrefs.HasKey("Rank"))
        {
            string[] ranked = PlayerPrefs.GetString("Rank", "").Split('\n');
            foreach (string rawscore in ranked)
            {
                if (int.TryParse(rawscore, out var sc)) 
                {
                    if (NewRank.Count > 0 && NewRank[^1] < score && score <= sc)
                    {
                        NewRank.Add(score);
                    }
                    NewRank.Add(sc);
                }
            }

            if (NewRank.Count > 0 && NewRank[^1] < score)
            {
                NewRank.Add(score);
            }
            PlayerPrefs.SetString("Rank", string.Join("\n", NewRank));
        }
        else PlayerPrefs.SetString("Rank", score.ToString());
    }
}
