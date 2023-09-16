using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerDash : MonoBehaviour
{
    PlayerController playerCon;
    [SerializeField] float dashSpeed;
    [SerializeField] float dashTime;
    [SerializeField] float dashCooldown = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerCon = GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerCon.energy > 19 && dashCooldown <= 0)
        {
            if (playerCon.GetEnergy() > 15)
            {
                StartCoroutine(Dash());
                dashCooldown = 1.0f;
            }
        } else
        {
            dashCooldown -= Time.deltaTime;
        }
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;
        playerCon.AbsorbObject(-10);
        while(Time.time < startTime + dashTime)
        {
            playerCon.controller.Move(playerCon.direction * dashSpeed * Time.deltaTime);
            yield return null;
        }



    }
}
