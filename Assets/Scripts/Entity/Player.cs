using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Entity
{
    [SerializeField] private float _speed;
    [SerializeField] private float _aimDistance;
    [SerializeField] private Projectile _projectilePrefab;

    [SerializeField] private float _shootDistance;

    [SerializeField] private Transform _boss;
    [SerializeField] private bool _isBossMoving;
    public ParticleSystem DamageParticle;

    private Vector3[] _positions = new Vector3[2];

    private void Update()
    {
        MoveUpdate();
        ShootUpdate();
    }

    public override void Damage(int damage)
    {
        base.Damage(damage);
        Instantiate(DamageParticle, transform.position, Quaternion.identity);
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
            var projectile = Instantiate(_projectilePrefab, transform.position + transform.forward * _shootDistance, Quaternion.identity);
            projectile.transform.LookAt(point);
            projectile.IsEnemyProjectile = false;
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
            // 2 * pi * r = 원주
            // 각도 * r = 움직이는 속도
            // 속도 / r = 각속도
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
