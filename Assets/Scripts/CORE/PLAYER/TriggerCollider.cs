using System.Collections.Generic;
using UnityEngine;

public class TriggerCollider : MonoBehaviour
{
    public List<IDamageable> ColliderTarget  = new();
    [SerializeField] private LayerMask TargetLayers;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & TargetLayers) != 0)
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null && !ColliderTarget.Contains(damageable))
            {
                ColliderTarget.Add(damageable);
                Debug.Log("Collider added: " + other.name);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable != null && ColliderTarget.Contains(damageable))
        {
            ColliderTarget.Remove(damageable);
            Debug.Log("Collider removed: " + other.name);
        }
    }
}
