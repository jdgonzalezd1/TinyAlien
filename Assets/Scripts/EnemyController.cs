using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public int damageTaken;
    PlayerController playerController;
    public GameObject player;
    private NavMeshAgent agent;
    private void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        player = FindAnyObjectByType<PlayerController>().gameObject;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {

        agent.destination = player.transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerController.AbsorbObject(damageTaken);
            Destroy(gameObject);
        }
    }

}
