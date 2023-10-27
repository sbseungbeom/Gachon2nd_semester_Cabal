using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameExitButton : MonoBehaviour
{
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
