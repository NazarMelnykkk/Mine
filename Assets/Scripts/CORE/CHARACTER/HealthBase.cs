using System;
using UnityEngine;

public class HealthBase : MonoBehaviour , IDamageable
{
    [SerializeField] protected HealthConfig _healthConfig;
    [SerializeField] protected int _health;
    [SerializeField] protected BarBase _bar;
    [SerializeField] protected float _knockbackForceMultiplier = 1000f;
    protected Rigidbody2D _rigidbody2D;


    public event Action<int , int> OnHealthChangedEvent;

    public virtual void Awake()
    {
        _health = _healthConfig.MaxHealth;
    }

    public virtual void  Start()
    {
        _bar.UpdateBar(_healthConfig.MaxHealth, _health);
    }


    public virtual void TakeDamage(int damageValue ,Transform damageDealer)
    {
        if (damageValue > 0)
        {
            _health -= damageValue;
            Knockbac(damageValue, damageDealer);
            if (_health <= 0)
            {
                _health = 0;
                Die();
            }

            HealthUpdated();
            _bar.UpdateBar(_healthConfig.MaxHealth, _health);
        }
    }

    public virtual void Knockbac(int damageValue, Transform damageDealer)
    {
        Vector2 knockbackDirection = (transform.position - damageDealer.position).normalized;
        float knockbackForce = damageValue * _knockbackForceMultiplier;
        _rigidbody2D.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
    }

    public virtual void HealthUpdated()
    {
        OnHealthChangedEvent?.Invoke(_healthConfig.MaxHealth , _health);
    }

    public virtual void Die() 
    { 

    }
}
