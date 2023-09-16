using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public int damageTaken;
    PlayerController playerController;
    public Transform player;
    private NavMeshAgent agent;
    private void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        agent.destination = player.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerController.AbsorbObject(damageTaken);
        }
    }

}
