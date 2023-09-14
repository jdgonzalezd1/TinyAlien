using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public int maxObjects = 40;
    public GameObject[] itemsToPickFrom;
    private List<GameObject> spawnedItems = new List<GameObject>();
    public GameObject character;
    float xMaxDistance,  zMaxDistance;
    float xMinDistance, zMinDistance;
    private float timeToCreateObject;
    
    const float FOODSIZE = 3f;
    const float XMIN = 2f , ZMIN = 2f;
    const float XMAX = 20f, ZMAX = 20f;




    // Start is called before the first frame update
    void Start()
    {
        TrackCharacterPosition();
        for (int i = 0; i < 10; i++)
        {
            PickAndSpawn(Quaternion.identity);
        }

        StartCoroutine(CreateObject());
    }

    private IEnumerator CreateObject()
    {
        timeToCreateObject = Random.Range(1, 3);

        yield return new WaitForSecondsRealtime(timeToCreateObject);

        if (spawnedItems.Count < maxObjects)
        {
            PickAndSpawn(Quaternion.identity);
        }

        StartCoroutine(CreateObject());

    }

    // Update is called once per frame
    void Update()
    {
    }

    private void PickAndSpawn(Quaternion rotationToSpawn)
    {
        TrackCharacterPosition();
        float xPosition = Random.Range(-xMaxDistance, xMaxDistance);
        float zPosition = Random.Range(-zMaxDistance, zMaxDistance);

        if (xPosition < xMinDistance && xPosition > -xMinDistance) xPosition += xMinDistance;
        if (zPosition < zMinDistance && zPosition > -zMinDistance) zPosition += zMinDistance;

        Vector3 positionToSpawn = new Vector3(xPosition, character.transform.position.y + 0.2f, zPosition);

        int randomIndex = Random.Range(0, itemsToPickFrom.Length);
        GameObject clone = Instantiate(itemsToPickFrom[randomIndex], positionToSpawn, rotationToSpawn);
        clone.transform.localScale = new Vector3(FOODSIZE, FOODSIZE, FOODSIZE);
        clone.transform.parent = transform;
        spawnedItems.Add(clone);
    }

    private void TrackCharacterPosition()
    {
        xMinDistance = character.transform.position.x + XMIN;
        xMaxDistance = character.transform.position.x + XMAX;
        zMinDistance = character.transform.position.z + ZMIN;
        zMaxDistance = character.transform.position.z + ZMAX;
    }
}
