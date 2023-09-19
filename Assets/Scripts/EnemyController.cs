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
    public AudioSource audioExplotion;
    public AudioClip explotion;
    private void Start()
    {
        audioExplotion = FindAnyObjectByType<PlayerController>().GetComponent<AudioSource>();
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
            audioExplotion.PlayOneShot(explotion, explotion.length);          

            Destroy(gameObject, 0.2f);
        }
    }

}
