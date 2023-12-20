using UnityEngine;

[CreateAssetMenu(fileName = "New Normal Stage Data", menuName = "ScriptableObjects/NormalStageData", order = 0)]
public class NormalStageData : StageData
{
    public float PlayerMinX = -30, PlayerMaxX = 30;
    public EnemySpawnData EnemySpawnData;
}