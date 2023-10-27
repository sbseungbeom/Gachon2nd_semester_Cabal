using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Player Player;

    private void Awake()
    {
        Instance = this;
    }


}