using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : Entity
{
    public static readonly Color DamagedColor = new(0.4f, 0.4f, 0.6f, 0.7f);

    private int _dir;

    public EnemyData Data;
    public Transform Rope;
    private SpriteRenderer _renderer;

    private float _timer = 0f;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _dir = Random.value < 0.5f ? 1 : -1;
    }

    public override void Damage(int damage)
    {
        base.Damage(damage);
        Instantiate(Data.DamageParticle, transform.position, Quaternion.identity);
    }

    private void OnDestroy()
    { 
        if(Rope != null) Destroy(Rope.gameObject);
    }

    protected override void OnDeath()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        _renderer.color = HP switch
        {
            1 => DamagedColor,
            _ => Color.white,
        };
        Rope.position += _dir * Data.MoveSpeed * Time.deltaTime * Vector3.right;
        if(transform.position.x < Data.MinX)
        {
            _dir = 1;
        }
        else if(transform.position.x > Data.MaxX)
        {
            _dir = -1;
        }

        if((_timer += Time.deltaTime) > Data.ShootCooldown)
        {
            _timer = 0f;

            var projectile = Instantiate(Data.projectile, transform.position, Quaternion.identity);
            projectile.transform.LookAt(GameManager.Instance.Player.transform);
            projectile.IsEnemyProjectile = true;
        }
    }
}
