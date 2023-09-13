using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 offset;
    [SerializeField] GameObject player;

    private void Start()
    {
        offset = new Vector3(0, 10, -5);
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }


}
