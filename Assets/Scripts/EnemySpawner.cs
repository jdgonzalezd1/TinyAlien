using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    Vector3 spawnStreet;
    public float spawnPosX, spawnPosZ;

    float startDelay = 1.0f;
    float spawnInterval = 3.0f;
    
    void Start()
    {
        InvokeRepeating("SpawnMissile", startDelay, spawnInterval);
    }

    void SpawnMissile()
    {
        spawnStreet = new Vector3(spawnPosX, 1, spawnPosZ);
        Instantiate(enemy, spawnStreet, enemy.transform.rotation);
    }



}
