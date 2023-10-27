using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Player Player;
    public int Score = 0;

    private void Awake()
    {
        Instance = this;
    }


}