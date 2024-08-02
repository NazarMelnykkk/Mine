using System;

public interface IReadOnlyInventorySlot 
{
    public event Action<string> OnItemIdChangedEvent;
    public event Action<int> OnItemAmountChangedEvent;

    public string ItemId { get;}
    public int Amount { get; }
    public bool IsEmpty { get; } 
}
