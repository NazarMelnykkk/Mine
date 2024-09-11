using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Inventory/Buildable Item")]
public class BuildableItem : Item
{
    
    [field: SerializeField] public TileBase Tile { get; private set; }

}
