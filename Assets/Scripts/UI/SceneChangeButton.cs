using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeButton : MonoBehaviour
{
    public string SceneName;
    public string currentSceneName;
    public void ChangeScene()
    {
        if (SceneManager.GetActiveScene().name != "ClearScene")
        {
            SceneStatic.previousScene = SceneManager.GetActiveScene().name;
        }
        SceneManager.LoadScene(SceneName);
    }
}
