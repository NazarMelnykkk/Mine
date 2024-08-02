using System.Collections.Generic;
using UnityEngine;

public class InventoryService 
{
    private readonly Dictionary<string, InventoryGrid> _inventoriesMap = new();
    private readonly InventoryDataProvider _inventoryDataProvider;

    public InventoryGrid RegisterInventory(InventoryGridData inventoryData)
    {
        var inventory = new InventoryGrid(inventoryData);
        _inventoriesMap[inventory.OwnerId] = inventory;

        return inventory;
    }

    public InventoryService(InventoryDataProvider inventoryDataProvider)
    {
        _inventoryDataProvider = inventoryDataProvider;
    }

    public AddItemToInventoryGridResult AddItemsToInventory(string ownerId, string itemId, int amount = 1)
    {
        var inventory = _inventoriesMap[ownerId];

        var result = inventory.AddItems(itemId, amount);
       _inventoryDataProvider.SaveData(this);

        return result;
    }

    public AddItemToInventoryGridResult AddItemsToInventory(string ownerId, Vector2Int slotCoords, string itemId, int amount = 1)
    {
        var inventory = _inventoriesMap[ownerId];

        var result = inventory.AddItems(slotCoords, itemId, amount);
       _inventoryDataProvider.SaveData(this);

        return result;

    }

    public RemoveItemFromInventoryGridResult RemoveItems(string ownerId, string itemId, int amount = 1)
    {
        var inventory = _inventoriesMap[ownerId];

        var result = inventory.RemoveItems(itemId, amount);
        _inventoryDataProvider.SaveData(this);

        return result;
    }

    public RemoveItemFromInventoryGridResult RemoveItems(string ownerId, Vector2Int slotCoords, string itemId, int amount = 1)
    {
        var inventory = _inventoriesMap[ownerId];

        var result = inventory.RemoveItems(slotCoords, itemId, amount);
        _inventoryDataProvider.SaveData(this);


        return result;
    }

    public bool Has(string ownerId, string itemId, int amount = 1)
    {
        var inventory = _inventoriesMap[ownerId];
        return inventory.Has(itemId, amount);
    }

    public IReadOnlyInventoryGrid GetInventory(string ownerId)
    {
        return _inventoriesMap[ownerId];
    }
}
