using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu_Script : MonoBehaviour
{
    public GameObject pauseMenuUI;
    GameObject[] enemy;
    GameObject[] spawner;
    PlayerController playerController;

    public void Start()
    {
        pauseMenuUI.SetActive(false);
        playerController = FindAnyObjectByType<PlayerController>();        
    }

    public void Update()
    {
        //Pause the game, and show the mouse cursor
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseMenuUI.activeInHierarchy == false)
            {
                pauseMenuUI.SetActive(true);
                playerController.SetMovement(false);
                enemy = GetEnemies();
                spawner = GetSpawner();
                for(int i = 0; i < enemy.Length; i++)
                {
                    enemy[i].SetActive(false);
                }
                for(int i = 0;i < spawner.Length; i++)
                {
                    spawner[i].SetActive(false);
                }
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                Resume();                
            }
        }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(1);
    }

    //unpause the game, and hide the mouse cursor 
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        playerController.SetMovement(true);
        for (int i = 0; i < enemy.Length; i++)
        {
            enemy[i].SetActive(true);
        }

        for (int i = 0; i< spawner.Length; i++)
        {
            spawner[i].SetActive(true);
        }
        enemy = null;
        spawner = null;
    }


    //send back to the main menu
    public void BackToMainMenu()
    {        
        SceneManager.LoadScene(0);
    }

    GameObject[] GetEnemies()
    {
        return GameObject.FindGameObjectsWithTag("Enemy");
    }

    GameObject[] GetSpawner()
    {
        return GameObject.FindGameObjectsWithTag("People");
    }
}