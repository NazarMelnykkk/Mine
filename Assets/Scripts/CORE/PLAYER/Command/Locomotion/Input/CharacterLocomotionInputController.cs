using UnityEngine;

public class CharacterLocomotionInputController 
{
    private CharacterCommandHandler _characterCommandHandler;

    public void Setup(CharacterCommandHandler characterCommandHandler)
    {
        _characterCommandHandler = characterCommandHandler;
        Subscribe();
    }

    public void Move(Vector2 direction)
    {
        _characterCommandHandler.SetCommand(new CharacterCommand(CommandType.Move, direction));
    }

    private void Subscribe()
    {
        DISystem.Instance.InputController.OnMovePerformedEvent += Move;
        DISystem.Instance.InputController.OnMoveCanceledEvent += Move;
    }

    public void Unsubscribe()
    {
        DISystem.Instance.InputController.OnMovePerformedEvent -= Move;
        DISystem.Instance.InputController.OnMoveCanceledEvent -= Move;
    }
}
