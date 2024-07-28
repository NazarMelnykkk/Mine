using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseHandler : MonoBehaviour
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

    private void OnEnable()
    {
        Debug.Log(References.Instance);
        //Debug.Log(References.Instance.);
        References.Instance.InputController.OnMenuPerformedEvent += TogglePause;
    }

    private void OnDisable()
    {
        References.Instance.InputController.OnMenuPerformedEvent -= TogglePause;
    }


}
