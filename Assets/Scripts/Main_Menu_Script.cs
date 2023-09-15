using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Main_Menu_Script : MonoBehaviour
{
    public GameObject startUI;
    public GameObject optionUI;
    public GameObject creditUI;


    public void Start()
    {
        startUI.SetActive(true);
        optionUI.SetActive(false);

    }
    public void CreditsUI()
    {
        startUI.SetActive(false);
        creditUI.SetActive(true);
    }
    public void OptionUI()
    {
        startUI.SetActive(false);
        optionUI.SetActive(true);
    }

    public void MainMenu()
    {
        startUI.SetActive(true);
        optionUI.SetActive(false);
        creditUI.SetActive(false);
    }


    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
