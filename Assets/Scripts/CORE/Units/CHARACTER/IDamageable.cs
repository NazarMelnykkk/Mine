using UnityEngine;

public interface IDamageable 
{
    public void TakeDamage(int damageValue, Transform damageDealer) { }

    public void Die() { }

    public void DamageImpact(int damageValue) { }
}
