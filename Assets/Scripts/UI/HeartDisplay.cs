using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartDisplay : MonoBehaviour
{
    public Image[] _hearts;

    private void Update()
    {
        for(int i = 0; i < _hearts.Length; i++)
        {
            if(i < GameManager.Instance.Player.HP)
            {
                _hearts[i].color = Color.white;
            }
            else
            {
                _hearts[i].color = new Color(0.3f, 0.3f, 0.6f, 0.9f);
            }
        }   
    }
}
