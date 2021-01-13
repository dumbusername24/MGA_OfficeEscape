using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MenuHandler : MonoBehaviour
{
    public GameObject MainMenu;
    public GameObject PauseMenu;

    public void PlayGame()
    {
        //this has to be the index in the build queue (file > build settings)
        SceneManager.LoadScene(2);
    }

    //public void BackToMainMenu()
    //{
    //    //this has to be the index in the build queue (file > build settings)
    //    PauseMenu.SetActive(false);
    //    MainMenu.SetActive(true);
    //}

    public void QuitGame()
    {
        Application.Quit();
    }
}
