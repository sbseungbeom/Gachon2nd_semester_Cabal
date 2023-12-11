using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackLaserProjectile : MonoBehaviour
{
    [SerializeField] int _damage;
    public bool IsRotating;
    float _rotationPow;
    private void Update()
    {
        if (IsRotating)
        {
            transform.Rotate(Vector3.up * _rotationPow * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player p))
        {
            p.Damage(_damage);
        }
    }
}
