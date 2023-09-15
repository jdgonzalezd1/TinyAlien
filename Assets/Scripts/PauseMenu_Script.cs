using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu_Script : MonoBehaviour
{
    public GameObject pauseMenuUI;

    public void Start()
    {
        pauseMenuUI.SetActive(false);
    }

    public void Update()
    {
        //Pause the game, and show the mouse cursor
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(pauseMenuUI.activeInHierarchy == false)
            {
                pauseMenuUI.SetActive(true);
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
        //Reset the game when the player fail or die.
    }

    //unpause the game, and hide the mouse cursor 
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }


    //send back to the main menu
    public void BackToMainMenu()
    {        
        SceneManager.LoadScene(0);
    }
}