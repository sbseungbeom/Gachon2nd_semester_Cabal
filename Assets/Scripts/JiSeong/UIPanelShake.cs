using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelShake : MonoBehaviour
{
    public float shakeDuration = 2f;// 흔들림 지속 시간
    public float shakeAmount = 3f;// 흔들림 정도

    private Vector3 originalPosition;
    private bool shakeTime = false;

    void Start()
    {
        originalPosition = transform.position;
    }

    private void Update()
    {
        if (shakeTime == true)
        {
            transform.position = originalPosition + Random.insideUnitSphere * shakeAmount;
        }
        else
        {
            transform.position = originalPosition;
        }
    }

    public void StartShake()
    {
        shakeTime = true;
    }
    public void EndShake()
    {
        shakeTime = false;
    }
}
