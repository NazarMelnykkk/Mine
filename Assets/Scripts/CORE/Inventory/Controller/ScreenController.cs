public class ScreenController 
{
    private readonly InventoryService _inventoryService;
    private readonly ScreenView _view;

    private InventoryGridController _currentInvontoryController;

    public ScreenController(InventoryService inventoryService, ScreenView view) 
    {
        _inventoryService = inventoryService;
        _view = view;
    }

    public void OpenInventory(string ownerId)
    {
        //dispose

        var inventory = _inventoryService.GetInventory(ownerId);
        var inventoryView = _view.inventoryView;

        _currentInvontoryController = new InventoryGridController(inventory, inventoryView);
    }


}
