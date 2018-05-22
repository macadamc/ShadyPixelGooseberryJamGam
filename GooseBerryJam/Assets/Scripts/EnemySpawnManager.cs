using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [Header("References")]
    public TransformRuntimeSet enemyTransformSet;
    public List<Transform> spawners = new List<Transform>();
    public List<GameObject> enemies = new List<GameObject>();

    [Header("Spawn Info")]
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 1.5f;
    public int currentMaxEnemyAmount = 1;
    public float maxEnemyIncreaseDelay = 5f;

    [HideInInspector]
    public float nextSpawnTime;
    [HideInInspector]
    public float nextMaxEnemyIncrease;

    public void OnEnable()
    {
        SetSpawnTime();
        SetNextMaxEnemyIncrease();
    }

    public void SetSpawnTime()
    {
        nextSpawnTime = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
    }


    public void SetNextMaxEnemyIncrease()
    {
        nextMaxEnemyIncrease = Time.time + maxEnemyIncreaseDelay;
    }

    public void Update()
    {
        if(Time.time >= nextSpawnTime)
        {
            if (enemyTransformSet.Items.Count >= currentMaxEnemyAmount)
                return;

            SpawnEnemy();
        }

        if(Time.time >= nextMaxEnemyIncrease)
        {
            SetNextMaxEnemyIncrease();
            currentMaxEnemyAmount++;
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
