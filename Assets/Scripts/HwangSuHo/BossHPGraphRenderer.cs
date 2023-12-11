using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPGraphRenderer : MonoBehaviour
{
    public static BossHPGraphRenderer Instance;
    [SerializeField] Slider _slider;
    private void Awake()
    {
        Instance = this;
    }
    // Update is called once per frame
    public void Render(float percentage)
    {
        _slider.value = percentage;
    }
}
