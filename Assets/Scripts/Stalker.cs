using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalker : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject player;
    private Vector3 pos;

    void Start()
    {
        pos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos = player.transform.position;
        transform.position = pos;
    }
}
