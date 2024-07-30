using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class InventoryEntryPoint : MonoBehaviour
{
    public InventoryGridView _view;

    public void Start()
    {
        var inventoryData = new InventoryGridData()
        {
            Size = new Vector2Int(3, 4),
            OwnerId = "Character",
            Slots = new List<InventorySlotData>()
        };

        var Size = inventoryData.Size;

        for (var x = 0; x < Size.x; x++)
        {
            for (var y = 0; y < Size.y; y++)
            {
                var index = x * Size.x + y;
                inventoryData.Slots.Add(new InventorySlotData());
            }
        }

        //zapoln

        var slotData = inventoryData.Slots[0];
        slotData.ItemId = "Предмет коза";
        slotData.Amount = 11;


        var inventory = new InventoryGrid(inventoryData);


        _view.Setup(inventory);

       
    }
}
