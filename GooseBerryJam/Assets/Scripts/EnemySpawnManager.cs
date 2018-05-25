using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    [Header("References")]
    public TransformRuntimeSet enemyTransformSet;
    public List<Transform> spawners = new List<Transform>();
    //public List<GameObject> enemies = new List<GameObject>();
    public WeightedGameObjectSet enemysSet;
    public WeightedGameObjectSet startingEnemys;

    [Header("Spawn Info")]
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 1.5f;
    public int currentMaxEnemyAmount = 1;
    public int totalMaxEnemyAmount = 20;
    public float maxEnemyIncreaseDelay = 5f;

    [HideInInspector]
    public float nextSpawnTime;
    [HideInInspector]
    public float nextMaxEnemyIncrease;

    public void OnEnable()
    {
        if (enemysSet.Items == null)
            enemysSet.Items = new List<WeightedGameObject>();

        enemysSet.Items.Clear();

        foreach (WeightedGameObject wObj in startingEnemys.Items)
        {
            enemysSet.Add(wObj);
        }

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

        if(Time.time >= nextMaxEnemyIncrease && currentMaxEnemyAmount < totalMaxEnemyAmount)
        {
            SetNextMaxEnemyIncrease();
            currentMaxEnemyAmount++;
        }
    }

    public void SpawnEnemy()
    {
        SetSpawnTime();

        Transform spawner = spawners[Random.Range(0, spawners.Count)];

        Instantiate(enemysSet.Choose()).transform.position = spawner.position;

    }
}
