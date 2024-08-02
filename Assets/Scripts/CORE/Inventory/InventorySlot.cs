using System;

public class InventorySlot : IReadOnlyInventorySlot
{
    public event Action<string> OnItemIdChangedEvent;
    public event Action<int> OnItemAmountChangedEvent;

    public string ItemId
    {
        get => _data.ItemId; 
        set 
        {
            if (_data.ItemId != value)
            {
                _data.ItemId = value;
                OnItemIdChangedEvent?.Invoke(value);
            }
        }
    }
    public int Amount
    {
        get => _data.Amount;
        set
        {
            if (_data.Amount != value)
            {
                _data.Amount = value;
                OnItemAmountChangedEvent?.Invoke(value);
            }
        }
    }
    public bool IsEmpty => Amount == 0 && string.IsNullOrEmpty(ItemId);


    private readonly InventorySlotData _data;

    public InventorySlot(InventorySlotData data)
    {
        _data = data;
    }
}
