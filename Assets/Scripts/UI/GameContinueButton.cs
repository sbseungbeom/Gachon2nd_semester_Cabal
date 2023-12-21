using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameContinueButton : MonoBehaviour
{
    public CanvasGroup ButtonGroup;
    public Button ContinueButton;

    private void Update()
    {
        ContinueButton.interactable = StageManager.HasRecentStageData;
        ButtonGroup.alpha = StageManager.HasRecentStageData ? 1f : 0.2f;
    }
}
