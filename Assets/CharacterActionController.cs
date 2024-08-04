using UnityEngine;
public class CharacterActionController : ICommandHandler
{
    [Header("Components")]
    private CharacterCommand _command;
    private Character _character; // take all info
    private Item _itemConfig;

    [Header("Actions")]
    CharacterAttackController _attackController;
    private bool _actionProcess = false;

    public void Setup(Character character)
    {
        _character = character;
        Init();
    }

    private void Init()
    {
        _attackController = new CharacterAttackController();
        _attackController.Setup(_character);
    }

    public void ProcessCommand(CharacterCommand command)
    {
        _command = command;

        if (_actionProcess == false)
        {
            _actionProcess = true;
            Action();
        }
    }

    private void Action()
    {
        _itemConfig = _character.GetCurrentItem();

        Action(_itemConfig.ActionType);
    }

    private async void Action(ItemActionType actionType)
    {
        switch (actionType)
        {
            case ItemActionType.Hit:
                await _attackController.Attack();
                StopCommand();
                break;

            default:
                StopCommand();
                break;
        }
    }

    public void StopCommand()
    {
        _command.IsComplete = true;
        _command = null;
        _actionProcess = false;
    }
}
