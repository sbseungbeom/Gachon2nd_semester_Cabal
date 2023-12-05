using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Player Player;
    public DamageScreen DamageScreen;
    public ScoreManager scoreManager;
    public SoundManager SoundManager;

    private void Awake()
    {
        Instance = this;
    }
}