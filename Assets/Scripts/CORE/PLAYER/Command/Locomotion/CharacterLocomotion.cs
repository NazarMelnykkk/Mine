using UnityEngine;

public class CharacterLocomotion : ICommandHandler
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
    private SpriteRenderer _spriteRenderer;

    public void Setup(LocomotionConfig config , GameObject obj)
    {
        _config = config;
        _gameObject = obj;
        Init();
    }

    private void Init()
    {
        _transform = _gameObject.transform;
        _rb = _gameObject.GetComponent<Rigidbody2D>();
        _spriteRenderer = _gameObject.GetComponentInChildren<SpriteRenderer>();
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

        if (_command.Direction.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else if(_command.Direction.x < 0)
        {
            _spriteRenderer.flipX = true;
        }

        _direction = _transform.up * _verticalDirection + _transform.right * _horizontalDirection;

        _rb.MovePosition(_rb.position + _direction.normalized * _config.Speed * Time.fixedDeltaTime);

        if (_command.Direction == Vector2.zero)
        {
            _command.IsComplete = true;
            return;
        }

    }
}
