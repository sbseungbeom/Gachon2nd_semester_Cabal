using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _aimDistance;
    [SerializeField] private Projectile _projectilePrefab;

    [SerializeField] private Transform _boss;
    [SerializeField] private bool _isBossMoving;

    private Vector3[] _positions = new Vector3[2];

    private void Update()
    {
        MoveUpdate();
        ShootUpdate();
    }

    private void ShootUpdate()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        var point = ray.GetPoint(_aimDistance);
        point.y = transform.position.y;

        if(ray.origin.y > transform.position.y && ray.direction.y < 0f)
        {
            var distance = (ray.origin.y - transform.position.y) / -ray.direction.y;
            point = ray.GetPoint(distance);
        }

        _positions[0] = transform.position;
        _positions[1] = transform.position + (point - transform.position) * 200;

        if (Input.GetMouseButtonDown(0))
        {
            var projectile = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
            projectile.transform.LookAt(point);
        }
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
