using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Update : MonoBehaviour
{
    public TextMesh Score;

    private void Awake()
    {
        Score = GetComponent<TextMesh>();
    }

    private void Update()
    {
        Score.text = Score_Manager.score.ToString();
    }
}
