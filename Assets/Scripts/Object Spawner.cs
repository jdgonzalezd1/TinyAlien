using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public int maxObjects = 20;
    public GameObject[] itemsToPickFrom;
    public GameObject character;
    float xMaxDistance,  zMaxDistance;
    float xMinDistance, zMinDistance;



    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 spawnPosition = new Vector3()
        }
    }

    // Update is called once per frame
    void Update()
    {
        xMinDistance = character.transform.position.x + 5f;
        xMaxDistance = character.transform.position.x + 30f;
        zMinDistance = character.transform.position.z + 5f;
        zMaxDistance = character.transform.position.z + 30f;
    }

    void PickAndSpawn(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        int randomIndex = Random.Range(0, itemsToPickFrom.Length);
        GameObject clone = Instantiate(itemsToPickFrom[randomIndex], positionToSpawn, rotationToSpawn);
    }
}
