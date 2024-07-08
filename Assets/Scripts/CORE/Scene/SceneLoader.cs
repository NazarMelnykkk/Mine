using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    [Header("Scene")]
    [SerializeField] private SceneField _systemScene;
    [SerializeField] private SceneField _menuScene;

    [Header("Actions")]
    public Action OnSceneLoadEvent;
    public Action OnSceneLoadedEvent;

    public Action OnRestartGameEvent;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Add(_menuScene);
    }

    public void Add(SceneField sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad.SceneName, LoadSceneMode.Additive);
    }

    public void Transition(SceneField sceneToLoad, string sceneToUnload)
    {

        SceneManager.UnloadSceneAsync(sceneToUnload);
        SceneManager.LoadScene(sceneToLoad.SceneName, LoadSceneMode.Additive);
    }

    public void RestartGameScene(string sceneToRestart)
    {
        RestartEvent();
        SceneManager.UnloadSceneAsync(sceneToRestart);
        SceneManager.LoadScene(sceneToRestart, LoadSceneMode.Additive);
    }

    private void StartLoadEvent()
    {
        OnSceneLoadEvent?.Invoke();  
    }

    private void EndLoadEvent()
    {
        OnSceneLoadedEvent?.Invoke();
    }

    private void RestartEvent()
    {
        OnRestartGameEvent?.Invoke();
    }

}