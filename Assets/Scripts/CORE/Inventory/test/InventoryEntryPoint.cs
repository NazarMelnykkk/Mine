using System.Collections.Generic;
using UnityEngine;

public class InventoryEntryPoint : MonoBehaviour
{
    [SerializeField] private ScreenView _ScreenView;

    private const string OWNER_1 = "CHARACTER";
    private const string OWNER_2 = "CHEST";

    private InventoryService _inventoryService;
    private ScreenController _screenController;
    private string _cashedOwnerId;
    private readonly string[] _itemIds = { "APPLE", "BANANA", "SEEED", "ARMOR", };

    public void Start()
    {
        //InventoryDataProvider inventoryDataProvider = new InventoryDataProvider();
       // _inventoryService = new InventoryService(inventoryDataProvider);

        var inventoryDataCharacter = CreaterTestInventory(OWNER_1);
        _inventoryService.RegisterInventory(inventoryDataCharacter);



        _screenController = new ScreenController(_inventoryService, _ScreenView);
        _screenController.OpenInventory(OWNER_1);

        _cashedOwnerId = OWNER_1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _screenController.OpenInventory(OWNER_1);
            _cashedOwnerId = OWNER_1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _screenController.OpenInventory(OWNER_2);
            _cashedOwnerId = OWNER_2;
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            var rIndex = Random.Range(0, _itemIds.Length);
            var rItemId = _itemIds[rIndex];
            var rAmount = Random.Range(1, 50);
            var result = _inventoryService.AddItemsToInventory(_cashedOwnerId, rItemId, rAmount);

            Debug.Log(result.ItemsNotAddedAmount);

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            var rIndex = Random.Range(0, _itemIds.Length);
            var rItemId = _itemIds[rIndex];
            var rAmount = Random.Range(1, 50);
            var result = _inventoryService.RemoveItems(_cashedOwnerId, rItemId, rAmount);

            Debug.Log(result.ItemsToRemoveAmount);

        }
    }

    private InventoryGridData CreaterTestInventory(string ownerId)
    {
        var size = new Vector2Int(3, 4);    
        var createInventorySlots = new List<InventorySlotData>();
        var lenght = size.x * size.y; // size from config
        for (var x = 0;x < lenght; x++)
        {
            createInventorySlots.Add(new InventorySlotData());

        }

        var createdInventoryData = new InventoryGridData()
        {
            OwnerId = ownerId,
            Size = size,
            Slots = createInventorySlots

        };

        return createdInventoryData;
    }
}
