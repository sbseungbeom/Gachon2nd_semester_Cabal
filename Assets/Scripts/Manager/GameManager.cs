using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Player Player;
    public DamageScreen DamageScreen;
    public int Score = 0;
    public SoundManager SoundManager;

    private void Awake()
    {
        Instance = this;
    }
}