using UnityEngine;

[CreateAssetMenu(menuName = "Config/Attack")]
public class AttackConfig : ScriptableObject
{
    public int BasicAttack = 1;
    public float AttackDelay = 0.6f;
}
