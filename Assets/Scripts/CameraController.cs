using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class   CameraController : MonoBehaviour
{
    public PlayerController player;
    public CinemachineVirtualCamera virtualCamera;
    private CinemachineTransposer transposer;
    private float scaleChange;

    private void Start()
    {
        transposer = virtualCamera.GetCinemachineComponent<CinemachineTransposer>();
    }

    private void LateUpdate()
    {
        scaleChange = player.scaleChange.y;
        transposer.m_FollowOffset = new Vector3(0, scaleChange * 1.46f + 0.56f, scaleChange * -1.37f - 1.26f);
    }


}
