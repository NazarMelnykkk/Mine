using UnityEngine;

public class CharacterCommandHandler : MonoBehaviour
{
    public CharacterCommand CurrentCommand;

    private CharacterInputController _inputController;

    [SerializeField] private TriggerCollider _triggerCollider;

    [Header("Locomotion")]
    private CharacterLocomotionController _characterMoveHandler;
    [SerializeField] private LocomotionConfig _locomotionConfig;

    [Header("Attack")]
    private CharacterAttackController _characterAttackController;
    [SerializeField] private AttackConfig _attackConfig;

    

    private void Start()
    {
        InitLocomotion();
        InitAttack();

        _inputController = new CharacterInputController();
        _inputController.Setup(this);
    }

    private void InitLocomotion()
    {
        _characterMoveHandler = new CharacterLocomotionController();
        _characterMoveHandler.Setup(_locomotionConfig, gameObject, _triggerCollider);
    }

    private void InitAttack()
    {
        _characterAttackController = new CharacterAttackController();
        _characterAttackController.Setup(_attackConfig, gameObject, _triggerCollider);
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
            case CommandType.Attack:
                ProcessAttackCommand();
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
        _characterAttackController.ProcessCommand(CurrentCommand);
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