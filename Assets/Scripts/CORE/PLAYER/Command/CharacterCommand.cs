using UnityEngine;

public class CharacterCommand
{
    public CommandType CommandType;

    public Vector2 Direction;
    public GameObject Target;

    public bool IsComplete;

    public CharacterCommand(CommandType commandType, Vector2 direction)
    {
        CommandType = commandType;
        Direction = direction;
    }

    public CharacterCommand(CommandType commandType, GameObject target)
    {
        CommandType = commandType;
        Target = target;
    }

    public CharacterCommand(CommandType commandType)
    {
        CommandType = commandType;
    }
}