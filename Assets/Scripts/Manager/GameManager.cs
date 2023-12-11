using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Player Player;
    public DamageScreen DamageScreen;
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
    }

    private void Start()
    {
        SoundManager.PlayBGM(StageManager.CurrentStageData.BackgroundMusic);
    }

}