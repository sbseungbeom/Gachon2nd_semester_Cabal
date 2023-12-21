
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager Instance;
    [SerializeField] private CanvasGroup _canvasGroup;

    public TutorialPanel ControllTutorial, ElementTutorial;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowTutorial(TutorialPanel panel)
    {
        Time.timeScale = 0f;
        _canvasGroup.alpha = 1f;
        panel.gameObject.SetActive(true);
    }

    public void Hide()
    {
        Time.timeScale = 1f;
        _canvasGroup.alpha = 0f;
    }
}