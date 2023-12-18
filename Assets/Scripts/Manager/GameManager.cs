using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Player Player;
    public DamageScreen DamageScreen;
    public CanvasGroup BlackScreen;
    public ScoreManager scoreManager;
    public SoundManager SoundManager;

    public BossCameraMove BossCamera;

    private void Awake()
    {
        Instance = this;

        Instantiate(StageManager.CurrentStageData.MapObject, Vector3.zero, Quaternion.identity);
        if(StageManager.CurrentStageData is BossStageData bossStageData)
        {
            Entity boss = Instantiate(bossStageData.Boss, Vector3.zero, Quaternion.identity);
            Player.Boss = boss.transform;
            BossCamera.Boss = boss.transform;
        }

        RenderSettings.skybox = StageManager.CurrentStageData.Skybox;

        StartCoroutine(HideBlack());
    }

    private IEnumerator HideBlack()
    {
        for (var i = 0f; i <= 1f; i += Time.deltaTime)
        {
            BlackScreen.alpha = 1 - i;
            yield return null;
        }
        BlackScreen.alpha = 0f;
    }

    public IEnumerator ShowBlack()
    {
        for (var i = 0f; i <= 1f; i += Time.deltaTime)
        {
            BlackScreen.alpha = i;
            yield return null;
        }
        BlackScreen.alpha = 1f;
    }

    private void Start()
    {
        SoundManager.PlayBGM(StageManager.CurrentStageData.BackgroundMusic);
    }

}