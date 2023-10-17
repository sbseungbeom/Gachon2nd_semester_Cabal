using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _aimDistance;
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private LineRenderer _aimLine;

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
        _aimLine.SetPositions(_positions);

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(_projectilePrefab, point, Quaternion.identity).speed = 0;
            var projectile = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
            projectile.transform.LookAt(point);
        }
    }

    private void MoveUpdate()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        transform.position += _speed * xAxis * Time.deltaTime * Vector3.right;
    }
}
