using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResetStartButton : MonoBehaviour
{
    public void ResetAndStart()
    {
        PlayerPrefs.SetInt("Score", 0);
        PlayerPrefs.SetInt("RecentStage", 1);
        SceneManager.LoadScene("StoryScene");
    }
}
