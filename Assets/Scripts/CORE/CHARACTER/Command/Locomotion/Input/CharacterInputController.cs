using UnityEngine;

public class CharacterInputController 
{
    private CharacterCommandHandler _characterCommandHandler;
    private Vector2 _currentDirection;

    public void Setup(CharacterCommandHandler characterCommandHandler)
    {
        _characterCommandHandler = characterCommandHandler;
        Subscribe();
    }

    private void Move(Vector2 direction)
    {
        _currentDirection = direction;
        _characterCommandHandler.SetCommand(new CharacterCommand(CommandType.Move, direction));
    }

    public Vector2 GetCurrentDirection()
    {
        return _currentDirection;
    }

    private void Action()
    {
        _characterCommandHandler.SetCommand(new CharacterCommand(CommandType.Action));
    }

    private void Subscribe()
    {
        References.Instance.InputController.OnMovePerformedEvent += Move;
        References.Instance.InputController.OnMoveCanceledEvent += Move;

        References.Instance.InputController.OnActionPerformedEvent += Action;


    }

    public void Unsubscribe()
    {
        References.Instance.InputController.OnMovePerformedEvent -= Move;
        References.Instance.InputController.OnMoveCanceledEvent -= Move;

        References.Instance.InputController.OnActionPerformedEvent -= Action;

    }
}
