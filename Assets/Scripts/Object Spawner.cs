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
    
    const float FOODSIZE = 5f;
    const float XMIN = 2f , ZMIN = 2f;
    const float XMAX = 20f, ZMAX = 20f;




    // Start is called before the first frame update
    void Start()
    {
        TrackCharacterPosition();
        for (int i = 0; i < 10; i++)
        {
            float xPosition = Random.Range(-xMaxDistance, xMaxDistance);
            float zPosition = Random.Range(-zMaxDistance, zMaxDistance);

            if (xPosition < xMinDistance && xPosition > -xMinDistance) xPosition += xMinDistance;
            if (zPosition < zMinDistance && zPosition > -zMinDistance) zPosition += zMinDistance;

            Vector3 spawnPosition = new Vector3(xPosition, character.transform.position.y + 3f, zPosition);
            PickAndSpawn(spawnPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        TrackCharacterPosition();
    }

    private void PickAndSpawn(Vector3 positionToSpawn, Quaternion rotationToSpawn)
    {
        int randomIndex = Random.Range(0, itemsToPickFrom.Length);
        GameObject clone = Instantiate(itemsToPickFrom[randomIndex], positionToSpawn, rotationToSpawn);
        clone.transform.localScale = new Vector3(FOODSIZE, FOODSIZE, FOODSIZE);
        clone.transform.parent = transform;
    }

    private void TrackCharacterPosition()
    {
        xMinDistance = character.transform.position.x + XMIN;
        xMaxDistance = character.transform.position.x + XMAX;
        zMinDistance = character.transform.position.z + ZMIN;
        zMaxDistance = character.transform.position.z + ZMAX;
    }
}
