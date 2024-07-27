using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [Header("Scene")]
    [SerializeField] private List<Scene> _scenes;   


    [Header("Actions")]
    public Action OnSceneLoadEvent;
    public Action OnSceneUnloadEvent;

    private void Start()
    {
        foreach (Scene scene in _scenes)
        {
            if (scene.LoadingOnInitialization == true)
            {
                Add(scene.SceneField);
            }
        }
    }

    public void Add(string sceneToLoad)
    {
        SceneField field = GetSceneFieldByString(sceneToLoad);

        SceneManager.LoadScene(field, LoadSceneMode.Additive);
        LoadEvent();
    }

    public void Transition(string sceneToLoad, string sceneToUnload)
    {
        UnloadEvent();
        SceneManager.UnloadSceneAsync(sceneToUnload);
    
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Additive);
        LoadEvent();
    }

    public void RestartGameScene(string sceneToRestart)
    {
        UnloadEvent(); //???
        SceneManager.UnloadSceneAsync(sceneToRestart);

        SceneManager.LoadScene(sceneToRestart, LoadSceneMode.Additive);
        LoadEvent();
    }

    private SceneField GetSceneFieldByString(string sceneName)
    {
        foreach (var scene in _scenes)
        {
            if(scene.SceneName == sceneName)
            {
                return scene.SceneField;
            }
        }

        return null;
    }

    private void LoadEvent()
    {
        OnSceneLoadEvent?.Invoke();  
    }

    private void UnloadEvent()
    {
        OnSceneUnloadEvent?.Invoke();
    }
}