using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Header("Scene")]
    [SerializeField] private SceneField _systemScene;
    [SerializeField] private SceneField _menuScene;


    [Header("Actions")]
    public Action OnSceneLoadEvent;
    public Action OnSceneLoadedEvent;

    public Action OnSceneUnloadEvent;

    public Action OnRestartGameEvent;

    public List<SceneField> ActiveScene; 

    private void Start()
    {
        Add(_menuScene);
    }

    public void Add(SceneField sceneToLoad)
    {
        StartLoadEvent();
        SceneManager.LoadScene(sceneToLoad.SceneName, LoadSceneMode.Additive);
        ActiveScene.Add(sceneToLoad);
        EndLoadEvent();
    }

    public void Transition(SceneField sceneToLoad, string sceneToUnload)
    {
        StartUnloadEvent();
        SceneManager.UnloadSceneAsync(sceneToUnload);
        ActiveScene.Remove(GetSceneFieldByString(sceneToUnload));

        StartLoadEvent();
        SceneManager.LoadScene(sceneToLoad.SceneName, LoadSceneMode.Additive);
        ActiveScene.Add(sceneToLoad);
        EndLoadEvent();
    }

    public void RestartGameScene(string sceneToRestart)
    {
        RestartEvent();
        StartUnloadEvent();
        SceneManager.UnloadSceneAsync(sceneToRestart);

        StartLoadEvent();
        SceneManager.LoadScene(sceneToRestart, LoadSceneMode.Additive);
        EndLoadEvent();
    }

    private SceneField GetSceneFieldByString(string sceneName)
    {
        foreach (var scene in ActiveScene)
        {
            if(scene.SceneName == sceneName)
            {
                return scene;
            }
        }

        return null;
    }

    private void StartLoadEvent()
    {
        OnSceneLoadEvent?.Invoke();  
    }

    private void EndLoadEvent()
    {
        OnSceneLoadedEvent?.Invoke();
    }

    private void StartUnloadEvent()
    {
        OnSceneUnloadEvent?.Invoke();
    }

    private void RestartEvent()
    {
        OnRestartGameEvent?.Invoke();
    }

}