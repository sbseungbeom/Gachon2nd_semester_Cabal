using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Projectile _projectilePrefab;

    private void Update()
    {
        MoveUpdate();
        ShootUpdate();
    }

    private void ShootUpdate()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            var point = ray.GetPoint(50);
            if (Physics.Raycast(ray, out var hit))
                point = hit.point;
            point.y = transform.position.y;
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
