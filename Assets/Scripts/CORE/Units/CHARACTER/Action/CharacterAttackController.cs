using System.Threading.Tasks;
using UnityEngine;

public class CharacterAttackController
{
    private AttackConfig _config;
    private Character _character;

    [Header("Components")]
    private AnimationController _characterAnimationController;
    private TriggerCollider _triggerCollider;
    private bool _isAttacking = false;

    public void Setup(Character character )
    {
        _character = character;
        Init();
    }

    private void Init()
    {
        _config = _character.AttackConfig; //???
        _triggerCollider = _character.TriggerCollider;
        _characterAnimationController = _character.AnimationController;
    }

    public async Task Attack()
    {
        if (_isAttacking == true)
        {
            return;
        }

        _isAttacking = true;

        _characterAnimationController.Attack();

        await Task.Delay((int)(_config.AttackDelay * 1000));

        Damage();

        await Task.Delay((int)(_config.AttackDelay * 1000));

        _characterAnimationController.Idle();
        StopAttack();
    }

    private async void StopAttack()
    {
        await Task.Delay((int)(_config.AttackDelay * 1000));
        _isAttacking = false;
    }

    private void Damage()
    {
        foreach (IDamageable target in _triggerCollider.ColliderTarget)
        {
            target.TakeDamage(_config.BasicAttack , _character.transform);
        }
    }
}