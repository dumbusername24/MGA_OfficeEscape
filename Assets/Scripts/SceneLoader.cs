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
    const int MainMenu = 1;
    const int PauseMenu = 2;
    const int VictoryScreen = 6;
    const int Timer = 3;
    const int FirstLevel = 4;

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
            if (SceneManager.GetSceneByBuildIndex(VictoryScreen).IsValid())
            {
                SceneManager.UnloadSceneAsync(VictoryScreen);
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
        if (!loading && !loadedScenes.Contains(PauseMenu))
        {
            AsyncOperation load = SceneManager.LoadSceneAsync(PauseMenu, LoadSceneMode.Additive);
            loading = true;
            sceneLoader.StartCoroutine(sceneLoader.CheckLoading(load));
            loadedScenes.Add(PauseMenu);
        }
    }

    static public void UnloadPauseMenu()
    {
        SceneManager.UnloadSceneAsync(PauseMenu);
        loadedScenes.Remove(PauseMenu);
    }

    static public void ReturnToMenu()
    {
        if (!loading)
        {
            UnloadAll();
            AsyncOperation load = SceneManager.LoadSceneAsync(MainMenu, LoadSceneMode.Additive);
            loading = true;
            sceneLoader.StartCoroutine(sceneLoader.CheckLoading(load));
            loadedScenes.Add(MainMenu);
        }
    }

    static public void StartGame()
    {
        if (!loading)
        {
            UnloadAll();
            sceneIndex = FirstLevel;
            SceneManager.LoadSceneAsync(Timer, LoadSceneMode.Additive);
            AsyncOperation load = SceneManager.LoadSceneAsync(FirstLevel, LoadSceneMode.Additive);
            loading = true;
            sceneLoader.StartCoroutine(sceneLoader.CheckLoading(load));
            loadedScenes.Add(Timer);
            loadedScenes.Add(FirstLevel);
        }
    }

    static public void EndLevel()
    {
        if (!loading)
        {
            SceneManager.UnloadSceneAsync(sceneIndex);
            loadedScenes.Remove(sceneIndex);
            AsyncOperation load = SceneManager.LoadSceneAsync(VictoryScreen, LoadSceneMode.Additive);
            loading = true;
            sceneLoader.StartCoroutine(sceneLoader.CheckLoading(load));
            loadedScenes.Add(VictoryScreen);
        }
    }

    static public void EndGame()
    {
        if (!loading)
        {
            UnloadAll();
            AsyncOperation load = SceneManager.LoadSceneAsync(VictoryScreen, LoadSceneMode.Additive);
            loading = true;
            sceneLoader.StartCoroutine(sceneLoader.CheckLoading(load));
            loadedScenes.Add(VictoryScreen);
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
            }
            yield return null;
        }
    }
}
