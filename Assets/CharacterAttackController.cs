using System.Threading.Tasks;
using UnityEngine;

public class CharacterAttackController
{
    private CharacterCommand _command;
    private AttackConfig _config;

    [Header("Components")]
    private GameObject _gameObject;
    private CharacterAnimationController _characterAnimationController;

    private bool _isAttacking = false;
    private Task _attackTask;

    public void Setup(AttackConfig config, GameObject obj)
    {
        _config = config;
        _gameObject = obj;
        Init();
    }

    private void Init()
    {
        _characterAnimationController = _gameObject.GetComponent<CharacterAnimationController>();
    }

    public void ProcessCommand(CharacterCommand command)
    {
        _command = command;
        Attack();
    }

    private async void Attack()
    {
        if (_isAttacking)
        {
            return;
        }

        if (!_command.Value && !_isAttacking)
        {
            Debug.Log("END ATTACK");
            _command.IsComplete = true;
            return;
        }
        else if (_command.Value && !_isAttacking)
        {
            if (_attackTask == null)
            {
                _isAttacking = true;
                _attackTask = AttackDelay();
                await _attackTask;
                _attackTask = null;
            }
        }
    }

    private async Task AttackDelay()
    {
        _characterAnimationController.Attack();
        await Task.Delay((int)(_config.AttackDelay * 1000));
        _isAttacking = false;
    }
}