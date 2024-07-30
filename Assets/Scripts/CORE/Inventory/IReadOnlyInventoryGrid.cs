using System;
using UnityEngine;

public interface IReadOnlyInventoryGrid : IReadOnlyInventory
{
    public event Action<Vector2Int> SizeChange;

    public Vector2Int Size { get;}

    IReadOnlyInventorySlot[,] GetSlots();

   
}
