public readonly struct AddItemToInventoryGridResult
{
    
    public readonly string InventoryOwnedId;
    public readonly int ItemsToAddAmount;
    public readonly int ItemsAddedAmount;

    public int ItemsNotAddedAmount => ItemsToAddAmount - ItemsAddedAmount;

    public AddItemToInventoryGridResult(string inventoryOwnedId, int itemsToAddAmount, int itemsAddedAmount)
    {
        InventoryOwnedId = inventoryOwnedId;
        ItemsToAddAmount = itemsToAddAmount;
        ItemsAddedAmount = itemsAddedAmount;
    }

}
