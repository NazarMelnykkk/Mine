using UnityEngine;

public class EffectController : MonoBehaviour
{
    [SerializeField] private CoreUnits _core;

    protected FlashEffect _flashEffect;
    protected KnockbackEffect _knockbackEffect;

    [Header("Flash")]
    [SerializeField] private Material _flashMetarial;


    private void Start()
    {
        _flashEffect = new FlashEffect(_core.SpriteHolder, _flashMetarial);

        _knockbackEffect = new KnockbackEffect(_core.gameObject, _core.Rigidbody2D);

    }


    public void KnockBack(int damageValue, Transform damageDealer)
    {
        _knockbackEffect.Knockback(damageValue, damageDealer);
    }

    public void Flash()
    {
        _flashEffect.Flash();
    }

}
