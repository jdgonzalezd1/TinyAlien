using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu_Script : MonoBehaviour
{
    public GameObject pauseMenuUI;
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
    }


    //send back to the main menu
    public void BackToMainMenu()
    {        
        SceneManager.LoadScene(0);
    }
}