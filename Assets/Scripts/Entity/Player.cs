using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(MeshRenderer))]
public class Player : Entity
{
    [SerializeField] private PlayerElementData _redElementData, _greenElementData, _blueElementData, _darkElementData;

    [SerializeField] private float _speed;
    [SerializeField] private float _aimDistance;
    [SerializeField] private Projectile _projectilePrefab;

    [SerializeField] private float _shootDistance;

    [SerializeField] private Transform _boss;
    [SerializeField] private bool _isBossMoving;
    [SerializeField] private Light _orbLight;

    public ParticleSystem DamageParticle;

    private Vector3[] _positions = new Vector3[2];
    private MeshRenderer _renderer;

    public PlayerElementData CurrentElement;

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();
        ChangeElement(CurrentElement, true);
    }

    private void Update()
    {
        MoveUpdate();
        ShootUpdate();
        ElementChangeUpdate();
    }

    private void ElementChangeUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            ChangeElement(_darkElementData);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            ChangeElement(_blueElementData);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            ChangeElement(_greenElementData);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            ChangeElement(_redElementData);
        }
    }

    public void ChangeElement(PlayerElementData data, bool slient = false)
    {
        _renderer.material = data.Material;
        _orbLight.color = data.LightColor;
        if(data.SpawnParticle != null && !slient) 
            ParticleManager.SpawnParticle(data.SpawnParticle, transform.position, transform);
        CurrentElement = data;
        GameManager.Instance.SoundManager.PlaySFX(GameManager.Instance.SoundManager.ElementChangeSound, transform);
    }

    public override void Damage(int damage)
    {
        base.Damage(damage);
        GameManager.Instance.DamageScreen.ShowDamage();
        ParticleManager.SpawnParticle(DamageParticle, transform.position);
    }

    private void ShootUpdate()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        var rayDir = ray.direction;
        if (rayDir.y >= 0f) rayDir.y = -0.005f;
        ray.direction = rayDir;

        var point = ray.GetPoint(_aimDistance);
        point.y = transform.position.y;

        if(ray.origin.y > transform.position.y)
        {
            var distance = (ray.origin.y - transform.position.y) / -ray.direction.y;
            point = ray.GetPoint(distance);
        }

        _positions[0] = transform.position;
        _positions[1] = transform.position + (point - transform.position) * 200;

        transform.LookAt(point);

        if (Input.GetMouseButtonDown(0))
        {
            if (CurrentElement.ProjectParticle != null)
                ParticleManager.SpawnParticle(CurrentElement.ProjectParticle, transform.position, transform);
            var projectile = Instantiate(CurrentElement.Projectile, transform.position + transform.forward * _shootDistance, Quaternion.identity);
            projectile.transform.LookAt(point);
            projectile.IsEnemyProjectile = false;
            GameManager.Instance.SoundManager.PlaySFX(GameManager.Instance.SoundManager.BaseAttackSound, transform);
        }
    }

    protected override void OnDeath()
    {
        SceneManager.LoadScene("GameOverScene");
    }

    private void MoveUpdate()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        if (_isBossMoving)
        {
            var bossDir = (transform.position - _boss.position);
            bossDir.y = 0;
            var distance = bossDir.magnitude;
            var angle = Mathf.Atan2(bossDir.z, bossDir.x);
            // 2 * pi * r = ����
            // ���� * r = �����̴� �ӵ�
            // �ӵ� / r = ���ӵ�
            angle += xAxis * Time.deltaTime * _speed / distance;
            transform.position = new Vector3(_boss.position.x, transform.position.y, _boss.position.z) 
                + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)).normalized * distance;
        }
        else
        {
            transform.position += _speed * xAxis * Time.deltaTime * Vector3.right;
        }
    }
}