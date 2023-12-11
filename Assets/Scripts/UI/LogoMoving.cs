using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class LogoMoving : MonoBehaviour
{
    public float bloomSpeed, scaleSpeed;
    public float bloomMin, bloomMax;
    public float scaleMin, scaleMax;

    [SerializeField] VolumeProfile volume;
    Bloom bloom;

    private void Awake()
    {
        if(!volume.TryGet(out bloom))
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        var bloomProgress = Mathf.Sin(Time.realtimeSinceStartup * bloomSpeed) / 2 + 1;
        var scaleProgress = Mathf.Sin(Time.realtimeSinceStartup * scaleSpeed) / 2 + 1;
        bloom.intensity.value = bloomProgress * (bloomMax - bloomMin) + bloomMin;
        transform.localScale = Vector3.one * (scaleProgress * (scaleMax - scaleMin) + scaleMin); 
    }
}
