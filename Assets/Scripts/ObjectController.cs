using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public float energyAmount;
    PlayerController player;

    private void Start()
    {
        player = FindAnyObjectByType<PlayerController>();
    }

    private void Update()
    {
        if (gameObject.tag == "City Object" && player.stage >= 2 ||
            gameObject.tag == "People" && player.stage >= 3 ||
            gameObject.tag == "Building" && player.stage >= 3)
        {
            gameObject.GetComponent<Collider>().isTrigger = true;
        }
    }
    bool CheckStage()
    {
        int playerStage = player.stage;
        if (gameObject.tag == "Food" && playerStage >= 1 ||
            gameObject.tag == "City Object" && playerStage >= 2 ||
            gameObject.tag == "People" && playerStage >= 3 ||
            gameObject.tag == "Building" && playerStage >= 3)
        {
            return true;
        }
        return false;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (CheckStage())
            {
                player.AbsorbObject(energyAmount);
                Destroy(gameObject);
            }
        }
    }

}
