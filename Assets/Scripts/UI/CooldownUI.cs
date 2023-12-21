using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownUI : MonoBehaviour
{
    public CanvasGroup group;

    private void Update()
    {
        group.alpha = StageManager.CurrentStageNumber > 1 ? 1f : 0f;
    }
}
