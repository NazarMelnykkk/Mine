using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public static CharacterInputActions InputActions;

    private void Awake()
    {
        InputActions = new CharacterInputActions();
        InputActions.Enable();
    }

    private void OnEnable()
    {
        InputActions.Character.MoveDirection.performed += MovePerformed;
        InputActions.Character.MoveDirection.canceled += MoveCanceled;

        InputActions.Character.Interaction.performed += InteractionPerformed;

    }

    private void OnDisable()
    {
        InputActions.Character.MoveDirection.performed -= MovePerformed;
        InputActions.Character.MoveDirection.canceled -= MoveCanceled;

        InputActions.Character.Interaction.performed -= InteractionPerformed;
    }

    #region Move

    public Action<Vector2> OnMovePerformedEvent;
    private void MovePerformed(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        OnMovePerformedEvent?.Invoke(direction);
    }

    public Action<Vector2> OnMoveCanceledEvent;
    private void MoveCanceled(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        OnMoveCanceledEvent?.Invoke(direction);
    }

    #endregion

    #region Interaction

    public Action OnInteractionPerformedEvent;

    private void InteractionPerformed(InputAction.CallbackContext context)
    {
        OnInteractionPerformedEvent?.Invoke();
    }
    #endregion

    #region Jump

    #endregion

    #region Jump

    #endregion

}
