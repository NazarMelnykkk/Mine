using UnityEngine;


public abstract class Item : ScriptableObject
{
    public string ItemName;
    public Sprite Icon;
    public ItemActionType ActionType;

    //public abstract void Use();
}
