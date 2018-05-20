using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    public List<Transform> spawners = new List<Transform>();
    public List<GameObject> enemies = new List<GameObject>();

    public float minSpawnTime = 1f;
    public float maxSpawnTime = 1.5f;
    public float nextSpawnTime;

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

        Transform spawner = spawners[Random.Range(0, spawners.Count)];
        GameObject enemy = enemies[Random.Range(0, enemies.Count)];

        Instantiate(enemy).transform.position = spawner.position;

    }
}
