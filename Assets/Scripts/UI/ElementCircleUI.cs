using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementCircleUI : MonoBehaviour
{
    public Image ElementImage;
    public Image DarkImage;
    public float SmoothTime;
    public float DarkCycle;

    private float _rotVel = 0f, _colVel = 0f;

    private void Update()
    {
        var angle = ElementImage.transform.eulerAngles;
        if(GameManager.Instance.Player.CurrentElement.ElementType == ElementType.Dark)
        {
            angle.z += Time.deltaTime * 360f * DarkCycle;
        }
        else
        {
            angle.z = Mathf.SmoothDampAngle(angle.z,
                GameManager.Instance.Player.CurrentElement.CircleRotation, ref _rotVel, SmoothTime);
        }
        DarkImage.transform.eulerAngles = angle;
        ElementImage.transform.eulerAngles = angle;

        var darkCol = DarkImage.color;
        darkCol.a = Mathf.SmoothDamp(darkCol.a, 
            GameManager.Instance.Player.CurrentElement.ElementType == ElementType.Dark ? 1f : 0f, 
            ref _colVel, SmoothTime);
        DarkImage.color = darkCol;
    }
}