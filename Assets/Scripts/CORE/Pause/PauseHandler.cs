using System;
using UnityEngine;

public class PauseHandler : IDisposable
{

    private PauseMenuController _pauseMenuController;


    /// <summary>
    /// USE ONLY FOR MAIN MENU
    /// </summary>
    /// 
    public void ToggleSetting()
    {
        _pauseMenuController.TogglePauseMenu();
    }

    public void GetSettingsMenu(PauseMenuController pauseMenuController)
    {
        _pauseMenuController = pauseMenuController;
    }

    public void TogglePause()
    {
        if (_pauseMenuController != null)
        {
            _pauseMenuController?.TogglePauseMenu();
        }
    }

    public void PauseGame()
    {
        Debug.Log("Game paused.");
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Debug.Log("Game resumed.");
        Time.timeScale = 1f; 
    }

    public void Setup()
    {
        References.Instance.InputController.OnMenuPerformedEvent += TogglePause;
    }

    public void Dispose()
    {
        References.Instance.InputController.OnMenuPerformedEvent -= TogglePause;
    }
}
