using UnityEngine;

[CreateAssetMenu(fileName = "New EnemySpawn Data", menuName = "ScriptableObjects/EnemySpawnData", order = 0)]
public class EnemySpawnData : ScriptableObject
{
    public RopeRenderer RopePrefab;
    public Enemy[] EnemyPrefabs;
    public int SpawnCount = 45;
    public int MaxSpawn = 6;
    public float SpawnSpan = 5f;
    public float[] SpawnZPos;
    public float SpawnYPos;
}