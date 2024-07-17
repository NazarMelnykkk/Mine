using UnityEngine;

public class CharacterInputController 
{
    private CharacterCommandHandler _characterCommandHandler;

    public void Setup(CharacterCommandHandler characterCommandHandler)
    {
        _characterCommandHandler = characterCommandHandler;
        Subscribe();
    }

    private void Move(Vector2 direction)
    {
        _characterCommandHandler.SetCommand(new CharacterCommand(CommandType.Move, direction));
    }

    private void AttackStart()
    {
        _characterCommandHandler.SetCommand(new CharacterCommand(CommandType.Attack, true));
    }

    private void AttackEnd()
    {
        _characterCommandHandler.SetCommand(new CharacterCommand(CommandType.Attack, false));
    }

    private void Subscribe()
    {
        DISystem.Instance.InputController.OnMovePerformedEvent += Move;
        DISystem.Instance.InputController.OnMoveCanceledEvent += Move;

        DISystem.Instance.InputController.OnFire1PerformedEvent += AttackStart;
        DISystem.Instance.InputController.OnFire1CanceledEvent += AttackEnd;
    }

    public void Unsubscribe()
    {
        DISystem.Instance.InputController.OnMovePerformedEvent -= Move;
        DISystem.Instance.InputController.OnMoveCanceledEvent -= Move;

        DISystem.Instance.InputController.OnFire1PerformedEvent -= AttackStart;
        DISystem.Instance.InputController.OnFire1CanceledEvent -= AttackEnd;
    }
}
