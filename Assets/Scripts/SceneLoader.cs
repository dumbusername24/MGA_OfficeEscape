using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    static private int sceneIndex;
    static private List<int> loadedScenes;
    static private bool loading = false;
    static private SceneLoader sceneLoader;
    const int MainMenuID = 1;
    const int PauseMenuID = 2;
    const int ActualVictoryScreenID = 4;
    const int VictoryScreenID = 7;
    const int TimerID = 3;
    const int FirstLevelID = 5;

    private void Start()
    {
        loadedScenes = new List<int>();
        sceneLoader = this;
        ReturnToMenu();
    }

    static public void Progress()
    {
        if (!loading)
        {
            if (SceneManager.GetSceneByBuildIndex(VictoryScreenID).IsValid())
            {
                SceneManager.UnloadSceneAsync(VictoryScreenID);
                loadedScenes.Remove(VictoryScreenID);
            }
            sceneIndex++;
            if (loadedScenes.Contains(sceneIndex))
            {
                Debug.Log("wtf happened?");
                ReturnToMenu();
            }
            else
            {
                AsyncOperation load = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
                loading = true;
                sceneLoader.StartCoroutine(sceneLoader.CheckLoading(load));
                //SceneManager.UnloadSceneAsync(sceneIndex - 1);
                loadedScenes.Add(sceneIndex);
                //loadedScenes.Remove(sceneIndex - 1);
                //Timer.timerOnOff = true;
            }
        }
    }

    static public void UnloadAll()
    {
        foreach (int scene in loadedScenes)
        {
            SceneManager.UnloadSceneAsync(scene);
        }
        loadedScenes.Clear();
    }

    static public void LoadPauseMenu()
    {
        if (!loading && !loadedScenes.Contains(PauseMenuID))
        {
            AsyncOperation load = SceneManager.LoadSceneAsync(PauseMenuID, LoadSceneMode.Additive);
            loading = true;
            sceneLoader.StartCoroutine(sceneLoader.CheckLoading(load));
            loadedScenes.Add(PauseMenuID);
        }
    }

    static public void UnloadPauseMenu()
    {
        SceneManager.UnloadSceneAsync(PauseMenuID);
        loadedScenes.Remove(PauseMenuID);
    }

    static public void ReturnToMenu()
    {
        if (!loading)
        {
            UnloadAll();
            AsyncOperation load = SceneManager.LoadSceneAsync(MainMenuID, LoadSceneMode.Additive);
            loading = true;
            sceneLoader.StartCoroutine(sceneLoader.CheckLoading(load));
            loadedScenes.Add(MainMenuID);
        }
    }

    static public void StartGame()
    {
        if (!loading)
        {
            UnloadAll();
            sceneIndex = FirstLevelID;
            SceneManager.LoadSceneAsync(TimerID, LoadSceneMode.Additive);
            AsyncOperation load = SceneManager.LoadSceneAsync(FirstLevelID, LoadSceneMode.Additive);
            loading = true;
            sceneLoader.StartCoroutine(sceneLoader.CheckLoading(load));
            loadedScenes.Add(TimerID);
            loadedScenes.Add(FirstLevelID);
        }
    }

    static public void EndLevel()
    {
        if (!loading)
        {
            SceneManager.UnloadSceneAsync(sceneIndex);
            loadedScenes.Remove(sceneIndex);
            Timer.timerOnOff = false;
            if (sceneIndex + 1 == VictoryScreenID)
            {
                AsyncOperation load = SceneManager.LoadSceneAsync(ActualVictoryScreenID, LoadSceneMode.Additive);
                loading = true;
                sceneLoader.StartCoroutine(sceneLoader.CheckLoading(load));
                loadedScenes.Add(ActualVictoryScreenID);
            }
            else
            {
                AsyncOperation load = SceneManager.LoadSceneAsync(VictoryScreenID, LoadSceneMode.Additive);
                loading = true;
                sceneLoader.StartCoroutine(sceneLoader.CheckLoading(load));
                loadedScenes.Add(VictoryScreenID);
            }
        }
    }

    static public void EndGame()
    {
        if (!loading)
        {
            UnloadAll();
            AsyncOperation load = SceneManager.LoadSceneAsync(VictoryScreenID, LoadSceneMode.Additive);
            loading = true;
            sceneLoader.StartCoroutine(sceneLoader.CheckLoading(load));
            loadedScenes.Add(VictoryScreenID);
        }
    }

    static private void SetLevelActive()
    {
        if (SceneManager.GetSceneByBuildIndex(sceneIndex).IsValid())
        {
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(sceneIndex));
        }
    }

    IEnumerator CheckLoading(AsyncOperation load)
    {
        while (loading)
        {
            if (load.isDone)
            {
                loading = false;
                SetLevelActive();
                Timer.timerOnOff = true;
            }
            yield return null;
        }
    }
}
