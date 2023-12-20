using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemySpawnData SpawnData;

    private float _spawnTimer = 0f;
    private List<Enemy> _list = new();
    private readonly Queue<Enemy> _prefabs = new();

    private bool _isCleared = false;

    private void Awake()
    {
        print(StageManager.CurrentStageData);
        if (StageManager.CurrentStageData is NormalStageData data)
        {
            SpawnData = data.EnemySpawnData;
            foreach(var certainData in SpawnData.EnemySpawns)
            {
                for(int i = 0; i < certainData.Count; i++)
                {
                    _prefabs.Enqueue(certainData.EnemyPrefab);
                }
            }
        }
    }

    private void Spawn()
    {
        if (_prefabs.Count <= 0)
        {
            return;
        }

        var enemyPrefab = _prefabs.Dequeue();
        var rope = Instantiate(SpawnData.RopePrefab, new Vector3(
            Random.Range(enemyPrefab.Data.MinX, enemyPrefab.Data.MaxX),
            SpawnData.SpawnYPos + enemyPrefab.Data.YOffset + SpawnData.RopePrefab.RopeLength,
            SpawnData.SpawnZPos[Random.Range(0, SpawnData.SpawnZPos.Length)]
            ), Quaternion.identity);
        var enemy = Instantiate(enemyPrefab, rope.transform.position, Quaternion.identity);
        enemy.Rope = rope.transform;

        enemy.transform.position = rope.transform.position;
        rope.End = enemy.transform;
        _list.Add(enemy);
    }

    private void Start()
    {
        var spawnCount = Random.Range(1, SpawnData.MaxSpawn + 1);
        for(int i = 0; i < spawnCount; i++)
        {
            Spawn();
        }
    }

    private void Update()
    {
        _list = _list.FindAll(e => e != null);

        if ((_spawnTimer += Time.deltaTime) > SpawnData.SpawnSpan)
        {
            _spawnTimer = 0f;
            if (_list.Count < SpawnData.MaxSpawn)
            {
                var spawnCount = Random.Range(1, SpawnData.MaxSpawn - _list.Count + 1);
                for (int i = 0; i < spawnCount; i++)
                {
                    Spawn();
                }
            }
        }

        if(_list.Count <= 0 && _prefabs.Count <= 0 && !_isCleared)
        {
            _isCleared = true;
            GameManager.Instance.Player.OnClear();
        }
    }
}
