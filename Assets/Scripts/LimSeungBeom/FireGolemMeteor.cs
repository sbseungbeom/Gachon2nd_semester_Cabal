using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGolemMeteor : MonoBehaviour
{
    int radius = 1;
    GameObject Player;
    Player PlayerScript;
    private void Start()
    {
        Player = GameManager.Instance.Player.gameObject;
        PlayerScript = Player.GetComponent<Player>();
    }

    private void OnEnable()
    {
        StartCoroutine(OverlapSphere());
        
    }

    IEnumerator OverlapSphere()
    {
        
        yield return new WaitForSeconds(0.75f);

        Vector3 center = transform.position;

        // SphereCast 수행
        Collider[] colliders = Physics.OverlapSphere(center, radius);

        // 감지된 물체에 대한 처리
        foreach (Collider collider in colliders)
        {
            if(collider.gameObject == Player)
            {
                PlayerScript.Damage(1);
            }
        }
        
    }
}

