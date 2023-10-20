using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    void Update ()
    {
        transform.position += Time.deltaTime * speed * transform.forward;
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject);
        if(other.CompareTag("Enemy")) Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject);
    }
}
