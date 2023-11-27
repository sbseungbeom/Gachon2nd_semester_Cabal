using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private RopeRenderer _ropePrefab;
    public Enemy[] Prefabs;
    public int SpawnCount = 45;
    public int MaxSpawn = 6;
    public float SpawnSpan = 5f;
    public float[] SpawnZPos;
    public float SpawnYPos;

    private float _spawnTimer = 0f;
    private List<Enemy> _list = new();


    private void Spawn()
    {
        if (SpawnCount <= 0) return;
        SpawnCount--;

        var enemyPrefab = Prefabs[Random.Range(0, Prefabs.Length)];
        var rope = Instantiate(_ropePrefab, new Vector3(
            Random.Range(enemyPrefab.Data.MinX, enemyPrefab.Data.MaxX),
            SpawnYPos + enemyPrefab.Data.YOffset,
            SpawnZPos[Random.Range(0, SpawnZPos.Length)]
            ), Quaternion.identity);
        var enemy = Instantiate(enemyPrefab, rope.transform.position, Quaternion.identity);
        enemy.Rope = rope.transform;

        enemy.transform.position = rope.transform.position;
        rope.End = enemy.transform;
        _list.Add(enemy);
    }

    private void Start()
    {
        var spawnCount = Random.Range(1, MaxSpawn + 1);
        for(int i = 0; i < spawnCount; i++)
        {
            Spawn();
        }
    }

    private void Update()
    {
        _list = _list.FindAll(e => e != null);

        if ((_spawnTimer += Time.deltaTime) > SpawnSpan)
        {
            _spawnTimer = 0f;
            if (_list.Count < MaxSpawn)
            {
                var spawnCount = Random.Range(1, MaxSpawn - _list.Count + 1);
                for (int i = 0; i < spawnCount; i++)
                {
                    Spawn();
                }
            }
        }

    }
}
