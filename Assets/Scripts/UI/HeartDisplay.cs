using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartDisplay : MonoBehaviour
{
    public Sprite liveHeart, brokenHeart;
    public Image[] _hearts;

    private void Update()
    {
        for(int i = 0; i < _hearts.Length; i++)
        {
            if(i < GameManager.Instance.Player.HP)
            {
                _hearts[i].sprite = liveHeart;
            }
            else
            {
                _hearts[i].sprite = brokenHeart;
            }
        }   
    }
}
