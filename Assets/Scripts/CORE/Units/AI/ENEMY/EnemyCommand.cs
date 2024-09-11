using UnityEngine;

public class EnemyCommand 
{
    public EnemyCommandType EnemyCommandType;
    public Vector2 Direction;
    public GameObject Target;

    public bool IsComplete;

    public EnemyCommand(EnemyCommandType commandType, Vector2 direction)
    {
        EnemyCommandType = commandType;
        Direction = direction;
    }

    public EnemyCommand(EnemyCommandType commandType, GameObject target)
    {
        EnemyCommandType = commandType;
        Target = target;
    }

    public EnemyCommand(EnemyCommandType commandType)
    {
        EnemyCommandType = commandType;
    }
}
