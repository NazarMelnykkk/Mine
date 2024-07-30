using System;

public interface IReadOnlyInventorySlot 
{
    public event Action<string> ItemIdChanged;
    public event Action<int> ItemAmountChanged;

    public string ItemId { get;}
    public int Amount { get; }
    public bool IsEmpty { get; } 
}
