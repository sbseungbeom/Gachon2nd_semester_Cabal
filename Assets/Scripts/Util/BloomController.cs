using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class BloomController : MonoBehaviour
{

    public float bloomSpeed;
    public float bloomMin, bloomMax;

    [SerializeField] VolumeProfile volume;
    Bloom bloom;

    private void Awake()
    {
        if (!volume.TryGet(out bloom))
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var bloomProgress = Mathf.Sin(Time.realtimeSinceStartup * bloomSpeed) / 2 + 1;
        bloom.intensity.value = bloomProgress * (bloomMax - bloomMin) + bloomMin;
    }
}
