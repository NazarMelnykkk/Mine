using System;

public interface IReadOnlyInventory 
{

    public event Action<string, int> ItemAdded;
    public event Action<string, int> ItemRemoved;

    string OwnerId { get;}

    public int GetAmount(string itemId);
    public bool Has(string itemId, int amount);


}
