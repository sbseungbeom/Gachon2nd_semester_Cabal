using UnityEngine;

[CreateAssetMenu(fileName = "New Boss Stage Data", menuName = "ScriptableObjects/BossStageData", order = 0)]
public class BossStageData : StageData
{
    public Entity Boss;
}