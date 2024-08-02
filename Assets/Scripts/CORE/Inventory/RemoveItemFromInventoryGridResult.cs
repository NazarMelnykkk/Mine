public readonly struct RemoveItemFromInventoryGridResult 
{
    public readonly string InventoryOwnedId;
    public readonly int ItemsToRemoveAmount;
    public readonly bool Succes;

    public RemoveItemFromInventoryGridResult(string inventoryOwnedId, int itemsToRemoveAmount, bool succes)
    {
        InventoryOwnedId = inventoryOwnedId;
        ItemsToRemoveAmount = itemsToRemoveAmount;
        Succes = succes;
    }
}
