using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score_Update : MonoBehaviour
{
    public string format;
    public TMP_Text Score;

    private void Awake()
    {
        Score = GetComponent<TMP_Text>();
    }

    private void Update()
    {
        Score.text = string.Format(format, Score_Manager.score.ToString());
    }
}
