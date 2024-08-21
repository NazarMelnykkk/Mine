using UnityEngine;
public class CharacterLocomotionController : ICommandHandler
{  
    private float _verticalDirection;
    private float _horizontalDirection;
    private Vector2 _direction;

    [Header("Components")]
    private CharacterCommand _command;
    private Character _character;

    private LocomotionConfig _config;
    private TriggerCollider _triggerCollider;
    private AnimationController _characterAnimationController;
    private Transform _transform;
    private Rigidbody2D _rb;

    public void Setup(Character character)
    {
        _character = character;
        Init();
    }

    private void Init()
    {
        _config = _character.LocomotionConfig;
        _triggerCollider = _character.TriggerCollider;
        _transform = _character.transform;
        _rb = _character.Rigidbody2D;
        _characterAnimationController = _character.AnimationController;
    }

    public void ProcessCommand(CharacterCommand command)
    {
        _command = command;
        Move();
    }

    private void Move()
    {
        _horizontalDirection = _command.Direction.x;
        _verticalDirection = _command.Direction.y;

        _direction = _transform.up * _verticalDirection + _transform.right * _horizontalDirection;

        _rb.MovePosition(_rb.position + _direction.normalized * _config.Speed * Time.fixedDeltaTime);


        if (_command.Direction == Vector2.zero)
        {
            _command.IsComplete = true;
            _characterAnimationController.Idle();
            return;
        }

        float angle = Mathf.Atan2(_verticalDirection, _horizontalDirection) * Mathf.Rad2Deg;
        _triggerCollider.transform.rotation = Quaternion.Euler(0, 0, angle);

        _characterAnimationController.Move(_direction);
    }
}
