using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPGraphRenderer : MonoBehaviour
{
    [SerializeField] Slider _slider;
    // Update is called once per frame
    public void Render(float percentage)
    {
        _slider.value = percentage;
    }
}
