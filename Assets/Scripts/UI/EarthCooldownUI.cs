using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class EarthCooldownUI : MonoBehaviour
{
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void Update()
    {
        _image.fillAmount = 1 - GameManager.Instance.Player.EarthRemainCooldown;
    }
}