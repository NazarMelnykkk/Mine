using UnityEngine;

public class EnemyHealth : HealthBase
{
    [SerializeField] protected Enemy _enemy;

    public override void Start()
    {
        base.Start();
        _rigidbody2D = _enemy.Rigidbody2D;
    }

    public override void Knockbac(int damageValue, Transform damageDealer)
    {
        base.Knockbac(damageValue , damageDealer);

    }
}
