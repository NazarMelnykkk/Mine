using UnityEngine;

public class CharacterLocomotionController : ICommandHandler
{
    private CharacterCommand _command;
    private LocomotionConfig _config;
    
    private float _verticalDirection;
    private float _horizontalDirection;
    private Vector2 _direction;

    [Header("Components")]
    private GameObject _gameObject;
    private Transform _transform;
    private Rigidbody2D _rb;
    private TriggerCollider _triggerCollider;
    private CharacterAnimationController _characterAnimationController;

    public void Setup(LocomotionConfig config , GameObject obj, TriggerCollider attackTrigger)
    {
        _config = config;
        _gameObject = obj;
        _triggerCollider = attackTrigger;
        Init();
    }

    private void Init()
    {
        _transform = _gameObject.transform;
        _rb = _gameObject.GetComponent<Rigidbody2D>();
        _characterAnimationController = _gameObject.GetComponent<CharacterAnimationController>();
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
