using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class WaterCooldownUI : MonoBehaviour
{
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Update()
    {
        _image.fillAmount = 1 - GameManager.Instance.Player.WaterRemainCooldown;
    }
}