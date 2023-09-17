using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public static EnergyBar instance;
    public Slider slider;
    public GameObject winScreen;
    public GameObject loseScreen;
    public PlayerController playerController;


    private void Start()
    {
        instance = this;
        playerController = FindAnyObjectByType<PlayerController>();
    }

    public void SetMaxEnergy(int energy)
    {
        slider.maxValue = energy;        
    }

    public void SetEnergy(int energy)
    {
        slider.value = energy;
    }

    public void WinCondition()
    {
        if(slider.value == slider.maxValue)
        {
            playerController.SetMovement(false);
            winScreen.SetActive(true);
        }

        if(slider.value <= 0)
        {
            playerController.SetMovement(false);
            loseScreen.SetActive(true);
        }
    }

}
