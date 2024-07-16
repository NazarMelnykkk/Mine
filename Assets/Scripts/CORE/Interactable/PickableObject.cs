using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableObject : InteractableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private int itemQuantity;

    public override void Interact(Character character)
    {
        base.Interact(character);
        character.PickUpItem(this);
        gameObject.SetActive(false);
    }


    public string GetItemName()
    {
        return itemName;
    }

    public int GetItemQuantity()
    {
        return itemQuantity;
    }
}
