using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrassDrakeAtk : MonoBehaviour
{
    GameObject Player;
    Player ps;
    // Start is called before the first frame update
    private void Awake()
    {
        Player = GameManager.Instance.Player.gameObject;
        ps = Player.GetComponent<Player>();
    }
    private void OnEnable()
    {
        StartCoroutine(explosion());
    }

    IEnumerator explosion()
    {
        Collider[] colliders = Physics.OverlapSphere(this.transform.position, 1);
        foreach (Collider collider in colliders)
        {
            if (collider.gameObject == Player)
            {
                ps.Damage(1); 
            }
        }   
        yield return new WaitForSeconds(1);

        Array.Clear(colliders, 0, colliders.Length);
    }

}