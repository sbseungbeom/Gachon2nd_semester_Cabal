using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementCircleUI : MonoBehaviour
{
    public Image ElementImage;
    public float SwingTime, RotSpeed;

    private float _targetRot = 0f;
    private float _swingTimer = 0f;
    private float _curZ = 0f;

    private void Start()
    {
        _curZ = ElementImage.transform.eulerAngles.z;
    }

    private void Update()
    {
        var curCircleRot = GameManager.Instance.Player.CurrentElement.CircleRotation;

        if(!Mathf.Approximately(curCircleRot, _targetRot))
        {
            _targetRot = curCircleRot;
            _swingTimer = SwingTime;
        }
        else if(_swingTimer > 0f)
        {
            _swingTimer -= Time.deltaTime;

            _curZ += Time.deltaTime * RotSpeed;

            if(_swingTimer <= 0f)
            {
                _curZ = (_curZ % 360f + 360f) % 360f - 360f;
                print($"Start {_curZ} END {_targetRot}");
            }
        }
        else if(_curZ < _targetRot)
        {
            _curZ += (_targetRot - _curZ) * Mathf.Clamp01(Time.deltaTime * 30f);
        }

        ElementImage.transform.eulerAngles = new Vector3(0, 0, _curZ);
    }
}