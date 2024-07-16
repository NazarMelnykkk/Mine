using UnityEngine;

public class ItemConfigBase : ScriptableObject
{
    public Sprite Image;
    public string Name;
    [Multiline] public string Description;
    public float Cost;
    public ItemRarityType Rarity;

    public int SizeWidth = 1;
    public int SizeHeight = 1;
}
