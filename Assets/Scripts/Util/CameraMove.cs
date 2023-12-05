using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _player, _boss;
    [SerializeField] private float _distanceFromPlayer, _yOffset;

    [SerializeField] private float _smoothTime;
    private Vector3 _targetPosition, _smoothVel;

    private void LateUpdate()
    {
        _targetPosition = _player.position + (_player.position - _boss.position).normalized * _distanceFromPlayer + Vector3.up * _yOffset;
        transform.LookAt(_boss);

        transform.position = Vector3.SmoothDamp(transform.position, _targetPosition, ref _smoothVel, _smoothTime);
    }
}
