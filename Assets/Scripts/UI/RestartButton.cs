using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    public void Restart()
    {
        var data = StageManager.CurrentStageData;
        if(data is BossStageData)
        {
            SceneManager.LoadScene("BossStage");
        }
        else if (data is NormalStageData)
        {
            SceneManager.LoadScene("NormalStage");
        }
    }
}
