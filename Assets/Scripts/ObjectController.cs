using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public readonly string[] objectType = {"food", "cityObject","person", "enemy", "building"};
    public float energyAmount;
    PlayerController player;
    [SerializeField] int typeIndex;

    private void Start()
    {
        player = FindAnyObjectByType<PlayerController>();
    }
    bool CheckStage()
    {
        int playerStage = player.stage;
        if (objectType[typeIndex] == "food" && playerStage >= 1
            || objectType[typeIndex] == "cityObject" && playerStage >= 2
            || objectType[typeIndex] == "person" && playerStage >= 3
            || objectType[typeIndex] == "building" && playerStage >= 3
            || objectType[typeIndex] == "enemy" && playerStage >= 3)
        {
            return true;
        } else
        {
            return false;
        }
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
