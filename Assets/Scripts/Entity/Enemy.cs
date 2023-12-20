using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Enemy : Entity
{
    public const float DamageShowTime = 0.3f;
    public static readonly Color DamagedColor = new(1f, 1f, 1f, 1f);

    private int _dir;

    public EnemyData Data;
    public Transform Rope;
    private SpriteRenderer _renderer;

    
    [SerializeField] AudioClip DamagedSound;

    private float _damageShowTimer = 0f;

    private float _timer = 0f;
    
    protected override void Awake()
    {
        base.Awake();
        _renderer = GetComponent<SpriteRenderer>();
        
        _dir = Random.value < 0.5f ? 1 : -1;
        _timer = Random.Range(0f, Data.ShootCooldown);
    }

    public override void Damage(int damage)
    {
        base.Damage(damage);
        _damageShowTimer = DamageShowTime;
        ParticleManager.SpawnParticle(Data.DamageParticle, transform.position);

        GameManager.Instance.SoundManager.PlaySFX(DamagedSound,transform.position,1,1);
    }

    protected virtual void OnDestroy()
    { 
        if(Rope != null) Destroy(Rope.gameObject);
    }

    protected override void OnDeath()
    {
        Destroy(gameObject);
        GameManager.Instance.scoreManager.score += Data.Score;//Á¡¼ö
    }

    protected virtual void Update()
    {
        Rope.position += _dir * Data.MoveSpeed * Time.deltaTime * Vector3.right;
        if(transform.position.x < Data.MinX)
        {
            _dir = 1;
        }
        else if(transform.position.x > Data.MaxX)
        {
            _dir = -1;
        }

        if((_timer -= Time.deltaTime) <= 0)
        {
            _timer = Data.ShootCooldown + Random.Range(0,Data.RandomShootCooldown);

            var vp = Camera.main.WorldToViewportPoint(transform.position);
            if (vp.x < 1 && vp.x > 0 && vp.y < 1 && vp.y > 0)
            {
                Attack();
            }
        }

        if(_damageShowTimer > 0f)
        {
            _damageShowTimer -= Time.deltaTime;

            _renderer.material.SetColor("_TintColor", DamagedColor * new Color(1f, 1f, 1f, _damageShowTimer / DamageShowTime));
        }
    }

    protected virtual void Attack() {
        var projectile = Instantiate(Data.projectile, transform.position, Quaternion.identity);
        projectile.transform.LookAt(GameManager.Instance.Player.transform.position);
        projectile.Owner = this;
    }

    protected IEnumerator Stop(float StopTime)
    {
        int SettedDir = _dir;
        _dir = 0;
        yield return new WaitForSeconds(StopTime);
        _dir = SettedDir;
    }
}
