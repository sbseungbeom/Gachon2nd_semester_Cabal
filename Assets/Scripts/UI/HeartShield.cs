using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartShield : MonoBehaviour
{
    public GameObject[] shields;

    // Update is called once per frame
    void Update()
    {
        foreach(var shield in shields) 
        {
            shield.SetActive(GameManager.Instance.Player.IsInvulnerable);
        }
    }
}
