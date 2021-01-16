using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class MenuHandler : MonoBehaviour
{
    //
    // Start Menu
    //
    public void PlayGame()
    {
        //this has to be the index in the build queue (file > build settings)
        //SceneManager.LoadScene(1);
        SceneLoader.StartGame();
    }

    public void NextLevel()
    {
        SceneLoader.Progress();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    //
    // Pause Menu
    //

    public void Backtomainmenu()
    {
        //this has to be the index in the build queue (file > build settings)
        //SceneManager.LoadScene(0);
        SceneLoader.ReturnToMenu();
        Timer.Reset();
    }

    public void ContinueGame()
    {
        Timer.timerOnOff = true;
        //SceneManager.UnloadSceneAsync(3);
        SceneLoader.UnloadPauseMenu();
    }
}
