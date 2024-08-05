using System;
using Unity.VisualScripting;
using UnityEngine;

public class PauseHandler : MonoBehaviour
{
    public Action OnPauseOnEvent;
    public Action OnPauseOffEvent;

    private PauseMenuController _pauseMenuController;
    private bool _isPause = false;

    public void GetSettingsMenu(PauseMenuController pauseMenuController)
    {
        _pauseMenuController = pauseMenuController;
    }

    public void TogglePause()
    {
        if (_pauseMenuController != null)
        {
            _isPause = !_isPause;

            _pauseMenuController.TogglePauseMenu(_isPause);
        }

        if (_isPause == true)
        {
            PauseGame();
            OnPauseOnEvent?.Invoke();
        }
        else 
        {
            ResumeGame();
            OnPauseOffEvent?.Invoke();
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

    public void OnEnable()
    {
        References.Instance.InputController.OnMenuPerformedEvent += TogglePause;
    }

    public void OnDisable()
    {
        References.Instance.InputController.OnMenuPerformedEvent -= TogglePause;
    }
}
