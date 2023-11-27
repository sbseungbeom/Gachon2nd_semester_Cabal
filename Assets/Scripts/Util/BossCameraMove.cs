using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class BossCameraMove : MonoBehaviour
{
    [SerializeField] private Transform _boss;
    [SerializeField] private Player _player;
    [SerializeField] private float _smoothTime = 0.5f;

    private Vector3 _vel;
    private float _distance;

    private void Awake()
    {
        var bossDir = (transform.position - _boss.position);
        _distance = bossDir.magnitude;
    }

    private void Update()
    {
        var cameraBossDir = (_boss.position - transform.position);
        cameraBossDir.y = 0f;
        var rotX = transform.eulerAngles.x;
        transform.forward = cameraBossDir;
        var angles = transform.eulerAngles;
        angles.x = rotX;
        transform.eulerAngles = angles;

        var bossDir = (_player.transform.position - _boss.position);
        bossDir.y = 0;
        var angle = Mathf.Atan2(bossDir.z, bossDir.x);
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(_boss.position.x, transform.position.y, _boss.position.z)
            + new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)).normalized * _distance, ref _vel, _smoothTime);
    }
}
