using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public bool IsEnemyProjectile;
    public int Damage = 1;
    public float DestroyDistance = 50f;
    public float DistanceCheckTime = 1f;

    [HideInInspector] public Vector3 CameraOffset;
    

    void Update ()
    {
        transform.position += Time.deltaTime * speed * transform.forward;

        var movement = Time.deltaTime * 3f;

        transform.position += -CameraOffset * movement;
        CameraOffset *= (1 - movement);
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject);
        if (other.TryGetComponent(out Entity ent) && !IsEnemyProjectile == (ent is Enemy))
        {
            ent.Damage(Damage);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        print(collision.gameObject);
    }
}
