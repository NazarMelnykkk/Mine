using UnityEngine;

public class CharacterCommandHandler : MonoBehaviour
{
    public CharacterCommand CurrentCommand;

    [Header("Locomotion")]
    private CharacterLocomotion _characterMoveHandler;
    private CharacterLocomotionInputController _inputController;
    [SerializeField] private LocomotionConfig _locomotionConfig;

    private void Start()
    {
        InitLoconotion();   
    }

    private void InitLoconotion()
    {
        _characterMoveHandler = new CharacterLocomotion();
        _characterMoveHandler.Setup(_locomotionConfig, gameObject);

        _inputController = new CharacterLocomotionInputController();
        _inputController.Setup(this);
    }

    /// <summary>
    ///REF: characterCommandHandler.SetCommand(new CharacterCommand(CommandType.Move, direction));
    /// </summary>
    /// <param name="newCommand"></param>
    public void SetCommand(CharacterCommand newCommand)
    {
        CurrentCommand = newCommand;
    }

    private void Update()
    {
        if (CurrentCommand == null)
        {
            return;
        }

        ProcessCommand();
    }

    private void ProcessCommand()
    {
        switch (CurrentCommand.CommandType)
        {
            case CommandType.None:
                break;
            case CommandType.Move:
                ProcessMoveCommand();
                break;            
            default:
                break;
        }

        if (CurrentCommand.IsComplete == true)
        {
            CompleteComand();
        }
    }

    private void CompleteComand()
    {
        CurrentCommand = null;
    }

    private void ProcessMoveCommand()
    {
        _characterMoveHandler.ProcessCommand(CurrentCommand);
    }

    private void ProcessAttackCommand()
    {
        //moveCommandHandler.ProcessCommand(CurrentCommand);
    }

    private void ProcessInteractCommand()
    {
        //moveCommandHandler.ProcessCommand(CurrentCommand);
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