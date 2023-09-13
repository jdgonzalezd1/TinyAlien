using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 offset;
    [SerializeField] GameObject player;
    PlayerController playerController;
    public Camera playerCamera;
    float sizeOffset;

    private void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        offset = new Vector3(0, 11, -5);
    }

    private void LateUpdate()
    {
        sizeOffset = playerController.transform.localScale.y * 0.5f;
        playerCamera.orthographicSize = sizeOffset;
        transform.position = player.transform.position + offset;
    }


}
