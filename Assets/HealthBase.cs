using System;
using UnityEngine;



public class HealthBase : MonoBehaviour , IDamageable
{
    [SerializeField] private HealthConfig _healthConfig;
    [SerializeField] private int _health;

    [SerializeField] private BarBase _bar;

    public event Action<int , int> OnHealthChangedEvent;

    private void Awake()
    {
        _health = _healthConfig.MaxHealth;
    }

    private void Start()
    {
        _bar.UpdateBar(_healthConfig.MaxHealth, _health);
    }


    public void TakeDamage(int damageValue)
    {
        if (damageValue > 0)
        {
            _health -= damageValue;
            if (_health <= 0)
            {
                _health = 0;
                Die();
            }

            HealthUpdated();
            _bar.UpdateBar(_healthConfig.MaxHealth, _health);
        }
    }

    public void HealthUpdated()
    {
        OnHealthChangedEvent?.Invoke(_healthConfig.MaxHealth , _health);
    }

    public void Die() 
    { 

    }
}
