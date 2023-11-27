using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStartSceneChange : MonoBehaviour
{
    public void ChangeScene()
    {
        SceneManager.LoadScene(SceneStatic.previousScene);
    }
}
