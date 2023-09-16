using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] PlayerController playerController;

    Vector3 spawnStreet;
    public int stageEnable;
    public float spawnPosX, spawnPosZ;
    public float spawnInterval = 5.0f;
    float startDelay = 1.0f;
    

    void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        InvokeRepeating("SpawnMissile", startDelay, spawnInterval);
    }

    void SpawnMissile()
    {
        if (stageEnable <= playerController.stage)
        {
            Debug.Log("Enable = " + stageEnable + " ---- Stage = " + playerController.stage);
            spawnStreet = new Vector3(spawnPosX, 1, spawnPosZ);
            Instantiate(enemy, spawnStreet, enemy.transform.rotation);
        }
    }




}
