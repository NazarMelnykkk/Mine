using UnityEngine;

public class KnockbackEffect 
{
    private GameObject _gameObject;
    private Rigidbody2D _rigidbody2D;
    private float _knockbackForceMultiplier = 1000f;

    public KnockbackEffect(GameObject thisObject, Rigidbody2D rigidbody2D)
    {
        _gameObject = thisObject;
        _rigidbody2D = rigidbody2D;
    }

    public virtual void Knockback(int damageValue, Transform damageDealer)
    {
        Vector2 knockbackDirection = (_gameObject.transform.position - damageDealer.position).normalized;
        float knockbackForce = damageValue * _knockbackForceMultiplier;
        _rigidbody2D.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
    }
}
