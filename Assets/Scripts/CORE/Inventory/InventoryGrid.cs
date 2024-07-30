using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGrid : IReadOnlyInventoryGrid
{
    public event Action<Vector2Int> SizeChange;
    public event Action<string, int> ItemAdded;
    public event Action<string, int> ItemRemoved;

    public string OwnerId => _data.OwnerId;
    public Vector2Int Size 
    { 
        get => _data.Size;
        set
        {
            if (_data.Size != value)
            {
                _data.Size = value;
                SizeChange?.Invoke(value);
            }
        }
    
    }

    private readonly InventoryGridData _data;
    private readonly Dictionary<Vector2Int, InventorySlot> _slotsMap = new();

    public InventoryGrid(InventoryGridData data)
    {
        _data = data;

        var size = _data.Size;

        for (var x = 0; x < size.x; x++)
        {
            for (var y = 0; y < size.y; y++)
            {
                var index = x * size.y + y;
                var slotData = data.Slots[index];
                var slot = new InventorySlot(slotData);
                var position = new Vector2Int(x, y);

                _slotsMap[position] = slot;
            }
        }
    }

    public int GetAmount(string itemId)
    {
        throw new NotImplementedException();
    }

    public IReadOnlyInventorySlot[,] GetSlots()
    {
        var array = new IReadOnlyInventorySlot[Size.x, Size.y];

        for (var x = 0; x < Size.x; x++)
        {
            for (var y = 0; y < Size.y; y++)
            {
                var position = new Vector2Int(x, y);

                array[x, y] = _slotsMap[position];
            }
        }

        return array;
    }

    public bool Has(string itemId, int amount)
    {
        throw new NotImplementedException();
    }

    public bool AddItems(string itemId, int amount)
    {
        throw new NotImplementedException();
    }
}
