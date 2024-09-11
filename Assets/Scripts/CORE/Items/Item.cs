using UnityEngine;


public abstract class Item : ScriptableObject
{
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField] public Sprite Icon { get; private set; }
    [field: SerializeField] public ItemActionType ActionType { get; private set; }

}
