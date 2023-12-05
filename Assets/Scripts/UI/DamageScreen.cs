using UnityEngine;
using UnityEngine.UI;

public class DamageScreen : MonoBehaviour
{
    private float _showDamageTimer = 0f, _maxShowDamageTime = 0f;
    [SerializeField] private Image _screenImage;

    private void Update()
    {
        var col = _screenImage.color;
        if (_showDamageTimer > 0f && _maxShowDamageTime > 0f)
        {
            _showDamageTimer -= Time.deltaTime;
            col.a = _showDamageTimer / _maxShowDamageTime;
        }
        else col.a = 0f;
        _screenImage.color = col;
    }

    public void ShowDamage(float time = 1f)
    {
        _maxShowDamageTime = _showDamageTimer = time;
    }
}