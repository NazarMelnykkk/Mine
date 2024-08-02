using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryGrid : IReadOnlyInventoryGrid
{
    public event Action<Vector2Int> SizeChange;
    public event Action<string, int> ItemAdded;
    public event Action<string, int> ItemRemoved;

    public string OwnerId => _data.OwnerId;
    public Vector2Int Size 
    { 
        get => _data.Size;
        set
        {
            if (_data.Size != value)
            {
                _data.Size = value;
                SizeChange?.Invoke(value);
            }
        }
    
    }

    private readonly InventoryGridData _data;
    private readonly Dictionary<Vector2Int, InventorySlot> _slotsMap = new();

    public InventoryGrid(InventoryGridData data)
    {
        _data = data;

        var size = _data.Size;

        for (var x = 0; x < size.x; x++)
        {
            for (var y = 0; y < size.y; y++)
            {
                var index = x * size.y + y;
                var slotData = data.Slots[index];
                var slot = new InventorySlot(slotData);
                var position = new Vector2Int(x, y);

                _slotsMap[position] = slot;
            }
        }
    }

    public AddItemToInventoryGridResult AddItems(string itemId, int amount = 1)
    {
        var remainingAmount = amount;
        var itemsAddedToSlotsWithSameItemsAmount = AddToSlotsWithSameItems(itemId, remainingAmount, out remainingAmount);

        if(remainingAmount <= 0)
        {
            return new AddItemToInventoryGridResult(OwnerId, amount, itemsAddedToSlotsWithSameItemsAmount);
        }

        var itemsAddedToAvailableSlotsAmount = AddToFirstAvailableSlots(itemId, remainingAmount, out remainingAmount);
        var totalAddedITemsAmount = itemsAddedToSlotsWithSameItemsAmount + itemsAddedToAvailableSlotsAmount;

        return new AddItemToInventoryGridResult(OwnerId, amount, totalAddedITemsAmount);


    }

    private int AddToFirstAvailableSlots(string itemId, int amount, out int remainingAmount)
    {
        var itemsAddedAmount = 0;
        remainingAmount = amount;

        for (var x = 0; x < Size.x; x++)
        {
            for (var y = 0; y < Size.y; y++)
            {
                var coords = new Vector2Int(x, y);
                var slot = _slotsMap[coords];

                if (slot.IsEmpty == false)
                {
                    continue;
                }

                slot.ItemId = itemId;
                var newValue = remainingAmount;
                var slotItemCapacity = GetItemSlotCapacity(slot.ItemId);

                if (newValue > slotItemCapacity)
                {
                    remainingAmount = newValue - slotItemCapacity;
                    var itemToAddAmount = slotItemCapacity;
                    itemsAddedAmount += itemToAddAmount;
                    slot.Amount = slotItemCapacity;
                }
                else
                {
                    itemsAddedAmount += remainingAmount;
                    slot.Amount = newValue;
                    remainingAmount = 0;

                    return itemsAddedAmount;
                }          
            }
        }

        return itemsAddedAmount;

    }

    private int AddToSlotsWithSameItems(string itemId, int amount, out int remainingAmount)
    {
        var itemsAddedAmount = 0;
        remainingAmount = amount;

        for (var x = 0; x < Size.x; x++)
        {
            for (var y = 0; y < Size.y; y++)
            {
                var coords = new Vector2Int(x, y);
                var slot = _slotsMap[coords];

                if (slot.IsEmpty == true)
                {
                    continue;
                }

                var slotItemCapacity = GetItemSlotCapacity(slot.ItemId);
                if (slot.Amount >= slotItemCapacity)
                {
                    continue;
                }

                if (slot.ItemId != itemId)
                {
                    continue;
                }

                var newValue = slot.Amount + remainingAmount;

                if (newValue > slotItemCapacity)
                {
                    remainingAmount = newValue - slotItemCapacity;
                    var itemsToAddAmount = slotItemCapacity - slot.Amount;
                    itemsAddedAmount += itemsToAddAmount;
                    slot.Amount = slotItemCapacity;

                    if (remainingAmount == 0)
                    {
                        return itemsAddedAmount;
                    }
                }
                else
                {
                    itemsAddedAmount += remainingAmount;
                    slot.Amount = newValue;
                    remainingAmount = 0;

                    return itemsAddedAmount;
                }
            }
        }

        return itemsAddedAmount;

    }

    public AddItemToInventoryGridResult AddItems(Vector2Int slotCoords, string itemId, int amount = 1)
    {
        var slot = _slotsMap[slotCoords];
        var newValue = slot.Amount + amount;
        var itemsAddedAmount = 0;

        //валидция если число больше 0

        if (slot.IsEmpty == true)
        {
            slot.ItemId = itemId;
        }

        var itemSlotCapacity = GetItemSlotCapacity(itemId);

        if (newValue > itemSlotCapacity)
        {
            var remainingItems = newValue - itemSlotCapacity;
            var itemsToAddAmount = itemSlotCapacity - slot.Amount;
            itemsAddedAmount += itemsToAddAmount;
            slot.Amount = itemSlotCapacity;

            var result = AddItems(itemId, remainingItems);
            itemsAddedAmount += result.ItemsAddedAmount;
        }
        else
        {
            itemsAddedAmount = amount;
            slot.Amount = newValue;
        }

        return new AddItemToInventoryGridResult(OwnerId, amount, itemsAddedAmount);
    }

    public RemoveItemFromInventoryGridResult RemoveItems(string itemId, int amount = 1)
    {
        if (Has(itemId, amount) == false)
        {
            return new RemoveItemFromInventoryGridResult(OwnerId, amount, false);
        }

        var amountToRemove = amount;

        for (var x = 0; x < Size.x; x++)
        {
            for (var y = 0; y < Size.y; y++)
            {
                var slotCoords = new Vector2Int(x, y);
                var slot = _slotsMap[slotCoords];

                if (slot.ItemId != itemId)
                {
                    continue;
                }

                if(amountToRemove > slot.Amount)
                {
                    amountToRemove -= slot.Amount;

                    RemoveItems(slotCoords, itemId, slot.Amount);
                }
                else
                {
                    RemoveItems(slotCoords, itemId, amountToRemove);

                    return new RemoveItemFromInventoryGridResult(OwnerId , amount, true);
                }


            }
        }

        throw new Exception("Something went wrong, counldn remove some items");
    }

    public RemoveItemFromInventoryGridResult RemoveItems(Vector2Int slotCoords, string itemId, int amount = 1)
    {
        var slot = _slotsMap[slotCoords];

        if (slot.IsEmpty || slot.ItemId != itemId || slot.Amount < amount)
        {
            return new RemoveItemFromInventoryGridResult(OwnerId, amount, false);
        }

        slot.Amount -= amount;

        if (slot.Amount == 0)
        {
            slot.ItemId = null;
        }

        return new RemoveItemFromInventoryGridResult(OwnerId, amount, true);
    }

    public int GetAmount(string itemId)
    {
        var amount = 0;
        var slots = _data.Slots;

        foreach (var slot in slots)
        {
            if (slot.ItemId == itemId)
            {
                amount += slot.Amount;
            }
        }

        return amount;
    }

    public IReadOnlyInventorySlot[,] GetSlots()
    {
        var array = new IReadOnlyInventorySlot[Size.x, Size.y];

        for (var x = 0; x < Size.x; x++)
        {
            for (var y = 0; y < Size.y; y++)
            {
                var position = new Vector2Int(x, y);

                array[x, y] = _slotsMap[position];
            }
        }

        return array;
    }

    public bool Has(string itemId, int amount)
    {
        var amountExist = GetAmount(itemId);
        return amountExist >= amount;
    }

    public void SwitchSlots(Vector2Int slotCoordsA, Vector2Int slotCoordsB)
    {
        var slotA = _slotsMap[slotCoordsA];
        var slotB = _slotsMap[slotCoordsB];
        var tempSlotItemId = slotA.ItemId;
        var tempSlotItemAmount = slotA.Amount;
        slotA.ItemId = slotB.ItemId;
        slotA.Amount = slotB.Amount;
        slotB.ItemId = tempSlotItemId;
        slotB.Amount = tempSlotItemAmount;
    }

    public void SetSize(Vector2Int newSize)
    {
        throw new NotImplementedException();
    }

    private int GetItemSlotCapacity(string itemId)
    {
        return 99; //место для того чтобы высрать код определния максимального количества в одном слоте предмета
    }
}
