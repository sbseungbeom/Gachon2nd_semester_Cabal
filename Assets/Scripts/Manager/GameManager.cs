using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Player Player;
    public DamageScreen DamageScreen;
    public int Score = 0;

    private void Awake()
    {
        Instance = this;
    }
}