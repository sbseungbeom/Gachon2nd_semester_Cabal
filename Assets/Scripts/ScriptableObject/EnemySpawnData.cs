using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New EnemySpawn Data", menuName = "ScriptableObjects/EnemySpawnData", order = 0)]
public class EnemySpawnData : ScriptableObject
{
    public RopeRenderer RopePrefab;
    public CertainEnemySpawnData[] EnemySpawns;
    
    public int MaxSpawn = 6;
    public float SpawnSpan = 5f;
    public float[] SpawnZPos;
    public float SpawnYPos;
}

[Serializable]
public class CertainEnemySpawnData
{
    public Enemy EnemyPrefab;
    public int Count;
}