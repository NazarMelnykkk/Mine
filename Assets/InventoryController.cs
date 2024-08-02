using UnityEngine;

public class InventoryController : MonoBehaviour , IDataPersistence
{
    [SerializeField] private string OwnerName = "Character";
    [SerializeField] private ScreenView _ScreenView;

    private InventoryService _inventoryService;
    private ScreenController _screenController;
    private InventoryDataProvider _inventoryDataProvider;
    private readonly string[] _itemIds = { "APPLE", "BANANA", "SEEED", "ARMOR", };

    public void SaveData(GameData data)
    {
        Debug.Log("SAVE");
        /*     _inventoryDataProvider*/
    }

    private void Start()
    {
        _inventoryDataProvider = new InventoryDataProvider(OwnerName, References.Instance.DataPersistenceHandlerBase.GameData);
        _inventoryDataProvider.LoadData();

        _inventoryService = new InventoryService(_inventoryDataProvider);
        _inventoryService.RegisterInventory(_inventoryDataProvider.LoadData());


        _screenController = new ScreenController(_inventoryService, _ScreenView);
        _screenController.OpenInventory(OwnerName);
    }

    public void LoadData(GameData data)
    {
        Debug.Log("LOadData");
    }


    private void Update()
    {
        

        if (Input.GetKeyDown(KeyCode.A))
        {
            var rIndex = Random.Range(0, _itemIds.Length);
            var rItemId = _itemIds[rIndex];
            var rAmount = Random.Range(1, 50);
            var result = _inventoryService.AddItemsToInventory(OwnerName, rItemId, rAmount);

            Debug.Log(result.ItemsNotAddedAmount);

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            var rIndex = Random.Range(0, _itemIds.Length);
            var rItemId = _itemIds[rIndex];
            var rAmount = Random.Range(1, 50);
            var result = _inventoryService.RemoveItems(OwnerName, rItemId, rAmount);

            Debug.Log(result.ItemsToRemoveAmount);

        }
    }
}
