using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public readonly string[] objectType = { "food", "cityObject", "enemy", "building" };
    public float energyAmount;
    PlayerController player;
    [SerializeField] int typeIndex;

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
        if (objectType[typeIndex] == "food" && playerStage >= 1)
        {
            return true;
        }else if (playerStage >= 2)
        {
            
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
