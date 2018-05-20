using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    List<List<Transform>> spawners;
    List<List<GameObject>> enemys;

    public List<Transform> spawnersBottom = new List<Transform>();
    public List<GameObject> enemiesBottom = new List<GameObject>();

    [Space]
    public List<Transform> spawnersTopWall = new List<Transform>();
    public List<GameObject> enemiesTopWall = new List<GameObject>();

    [Space]
    public List<Transform> spawnersFlying = new List<Transform>();
    public List<GameObject> enemiesFlying = new List<GameObject>();
  
    [Space]
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 1.5f;
    public float nextSpawnTime;

    private void Awake()
    {
        spawners = new List<List<Transform>>() { spawnersBottom, spawnersTopWall, spawnersFlying };
        enemys = new List<List<GameObject>>() { enemiesBottom, enemiesTopWall, enemiesFlying };
    }

    public void SetSpawnTime()
    {
        nextSpawnTime = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
    }

    public void Update()
    {
        if(Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
        }
    }

    public void SpawnEnemy()
    {
        SetSpawnTime();

        int SpawnerIndex = Random.Range(0, spawners.Count);
        Transform spawner = spawners[SpawnerIndex][Random.Range(0, spawners[SpawnerIndex].Count)];

        if(enemys[SpawnerIndex].Count > 0)
        {
            GameObject enemy = enemys[SpawnerIndex][Random.Range(0, enemys[SpawnerIndex].Count)];
            Instantiate(enemy).transform.position = spawner.position;
        }
    }
}
