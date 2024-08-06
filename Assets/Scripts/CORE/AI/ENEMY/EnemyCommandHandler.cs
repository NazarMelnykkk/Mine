using UnityEngine;

public class EnemyCommandHandler : MonoBehaviour
{
    public EnemyCommand CurrentCommand;
    [SerializeField] private Enemy _enemy;
    private CharacterInputController _inputController;

    private EnemyFollowController _enemyFollowController;
     
    private bool _isCommandProcessing = false;

    private void Start()
    {

    }


    public void SetCommand(EnemyCommand newCommand)
    {
        if (_isCommandProcessing == true)
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

    private void ProcessCommand(EnemyCommand EnemyCommand)
    {
        switch (EnemyCommand.EnemyCommandType)
        {
            case EnemyCommandType.None:
                break;
            case EnemyCommandType.Idle:
                break;
            case EnemyCommandType.Patrol:
                break;
            case EnemyCommandType.Follow:
                break;
            case EnemyCommandType.Attack:
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
    }

    private void ProcessMoveCommand()
    {
        
    }


    public EnemyCommandType GetCurrentCommandType()
    {
        if (CurrentCommand == null)
        {
            return EnemyCommandType.None;
        }

        return CurrentCommand.EnemyCommandType;
    }
}
