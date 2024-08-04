using UnityEngine;

public class CharacterCommandHandler : MonoBehaviour
{
    public CharacterCommand CurrentCommand;
    [SerializeField] private Character _character;
    private CharacterInputController _inputController;

    [Header("Locomotion")]
    private CharacterLocomotionController _characterMoveHandler;

    [Header("Action")]
    private CharacterActionController _characterActionController;

    private bool _isCommandProcessing = false;

    private void Start()
    {
        InitLocomotion();
        InitAction();

        _inputController = new CharacterInputController();
        _inputController.Setup(this);
    }

    private void InitLocomotion()
    {
        _characterMoveHandler = new CharacterLocomotionController();
        _characterMoveHandler.Setup(_character);
    }

    private void InitAction()
    {
        _characterActionController = new CharacterActionController();
        _characterActionController.Setup(_character);
    }

    public void SetCommand(CharacterCommand newCommand)
    {
        if (_isCommandProcessing == true && GetCurrentCommandType() != CommandType.Move)
        {
            return;
        }

        _isCommandProcessing = true;
        CurrentCommand = newCommand;
    }

    private void FixedUpdate()
    {
        if (CurrentCommand != null)
        {
            ProcessCommand(CurrentCommand);
        }
    }

    private void ProcessCommand(CharacterCommand CharacterCommand)
    {
        switch (CharacterCommand.CommandType)
        {
            case CommandType.None:
                break;
            case CommandType.Move:
                ProcessMoveCommand();
                break;
            case CommandType.Action:
                ProcessActionCommand();
                break;
            default:
                break;
        }

        if (CurrentCommand.IsComplete == true)
        {
            CompleteCommand();
        }
    }

    private void CompleteCommand()
    {
        CurrentCommand = null;
        _isCommandProcessing = false;

        Vector2 currentDirection = _inputController.GetCurrentDirection();
        if (currentDirection != Vector2.zero)
        {
            SetCommand(new CharacterCommand(CommandType.Move, currentDirection));
        }
    }

    private void ProcessMoveCommand()
    {
        _characterMoveHandler.ProcessCommand(CurrentCommand);
    }

    private void ProcessActionCommand()
    {
        _characterActionController.ProcessCommand(CurrentCommand);
    }

    public CommandType GetCurrentCommandType()
    {
        if (CurrentCommand == null)
        {
            return CommandType.None;
        }

        return CurrentCommand.CommandType;
    }
}