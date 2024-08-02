using System;

public class InventorySlotController 
{
    private readonly InventorySlotView _view;

    public InventorySlotController(IReadOnlyInventorySlot slot, InventorySlotView view)
    {
        _view = view;

        slot.OnItemIdChangedEvent += OnSlotItemIdChanged;
        slot.OnItemAmountChangedEvent += OnSlotItemAmountChanged;

        view.Title = slot.ItemId;
        view.Amount = slot.Amount;
    }

    private void OnSlotItemIdChanged(string newItemId)
    {
        _view.Title = newItemId;
    }
    private void OnSlotItemAmountChanged(int newAmount)
    {
        _view.Amount = newAmount;
    }

}
