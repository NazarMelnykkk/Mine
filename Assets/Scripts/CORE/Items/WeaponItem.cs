using UnityEngine;

[CreateAssetMenu(menuName = "Inventory/Weapon Item")]
public class WeaponItem : Item
{
    [field: SerializeField] public int Damage;
}
