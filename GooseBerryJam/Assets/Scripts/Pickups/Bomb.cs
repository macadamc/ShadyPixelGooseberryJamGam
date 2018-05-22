using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    EnemySpawnManager esm;

    public int EnemySpawnChange = 5;
    public TransformRuntimeSet activeEnemys;

    public void Awake()
    {
        esm = GameObject.FindObjectOfType<EnemySpawnManager>();
    }

    public void Explode()
    {
        foreach(Transform  t in activeEnemys.Items)
        {
            t.GetComponent<Health>().Set(0);
        }

        esm.currentMaxEnemyAmount = Mathf.Clamp(esm.currentMaxEnemyAmount + -EnemySpawnChange, 1, int.MaxValue);
    }
}
