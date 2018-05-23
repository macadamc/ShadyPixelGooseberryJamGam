using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawnManager : MonoBehaviour {

    public TransformRuntimeSet ActivePickups;
    //public List<GameObject> pickups;
    public WeightedGameObjectSet startingSet;
    public WeightedGameObjectSet pickups;

    public float minSpawnTime;
    public float maxSpawnTime;

    public float edgePadding;
    public float spawnHeight = 5f;

    public int maxActivePickups;

    float nextSpawnTime;
    Camera cam;
    float camWidth;
    float camHeight;
    float wallTopY;

    
    public void SetSpawnTime()
    {
        nextSpawnTime = Time.time + Random.Range(minSpawnTime, maxSpawnTime);
    }

    private void Awake()
    {
        if (ActivePickups.Items == null)
            ActivePickups.Items = new List<Transform>();
        pickups.Items.Clear();
        cam = Camera.main;
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;
        wallTopY = GameObject.FindGameObjectWithTag("Finish").transform.position.y;

        SetSpawnTime();

        
        foreach(WeightedGameObject wObj in startingSet.Items)
        {
            pickups.Add(wObj);
        }
    }

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            if (ActivePickups.Items.Count >= maxActivePickups)
                return;

            Spawn();
            SetSpawnTime();
        }
    }

    public void Spawn()
    {
        Vector2 sPos = new Vector2(
            Random.Range(-camWidth / 2f + edgePadding, camWidth / 2f - edgePadding) + cam.transform.position.x,
            Random.Range(wallTopY, wallTopY + spawnHeight)
            );

        //GameObject pickup = pickups[Random.Range(0, pickups.Count)];
        Instantiate(pickups.Choose()).transform.position = sPos;
    }

}
