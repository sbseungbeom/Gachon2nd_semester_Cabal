using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class NormalCameraMove : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private float _smoothTime = 0.5f;

    private Vector3 _vel;

    private void Awake()
    {
        transform.position = Vector3.SmoothDamp(transform.position, _player.transform.position, ref _vel, _smoothTime);
    }
}
