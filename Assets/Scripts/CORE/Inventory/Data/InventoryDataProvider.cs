using System.Collections.Generic;
using UnityEngine;

public class InventoryDataProvider
{
    private readonly string _ownerId;
    private readonly GameData _gameData;

    public InventoryDataProvider(string ownerId, GameData gameData)
    {
        _ownerId = ownerId;
        _gameData = gameData;
    }

    public void SaveData(InventoryService inventoryService)
    {
        var inventoryGrid = inventoryService.GetInventory(_ownerId);
        var inventoryGridData = ConvertToInventoryGridData(inventoryGrid);

        if (_gameData.InventoriesData.InventoriesGridData.ContainsKey(_ownerId))
        {
            _gameData.InventoriesData.InventoriesGridData[_ownerId] = inventoryGridData;
        }
        else
        {
            _gameData.InventoriesData.InventoriesGridData.Add(_ownerId, inventoryGridData);
        }
    }


    public InventoryGridData LoadData() 
    {      
        InventoryGridData InventoryGridData;

        if (_gameData.InventoriesData.InventoriesGridData.TryGetValue(_ownerId, out InventoryGridData))
        {
            Debug.Log("LOAD from Save");
            return InventoryGridData;
        }
        else
        {
            Debug.Log("LOAD from settings");
            return InitFromSettings();
        }     
    }

    public InventoryGridData ConvertToInventoryGridData(IReadOnlyInventoryGrid inventoryGrid)
    {
        var data = new InventoryGridData
        {
            OwnerId = inventoryGrid.OwnerId,
            Size = inventoryGrid.Size,
            Slots = new List<InventorySlotData>()
        };

        var slots = inventoryGrid.GetSlots();
        for (var x = 0; x < inventoryGrid.Size.x; x++)
        {
            for (var y = 0; y < inventoryGrid.Size.y; y++)
            {
                var slot = slots[x, y];
                data.Slots.Add(new InventorySlotData
                {
                    ItemId = slot.ItemId,
                    Amount = slot.Amount
                });
            }
        }

        return data;
    }

    public InventoryGridData InitFromSettings()
    {
        var size = new Vector2Int(3, 4);
        var createInventorySlots = new List<InventorySlotData>();
        var lenght = size.x * size.y; // size from config
        for (var x = 0; x < lenght; x++)
        {
            createInventorySlots.Add(new InventorySlotData());

        }

        var createdInventoryData = new InventoryGridData()
        {
            OwnerId = _ownerId,
            Size = size,
            Slots = createInventorySlots

        };

        return createdInventoryData;
    }

}
