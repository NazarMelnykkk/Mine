using UnityEngine;

public class Character : CoreUnits
{



    [Header("Commmand")]
    public CharacterCommandHandler CharacterCommandHandler;

    [Header("Inventory")]
    public CharacterViewHolder CharacterViewHolder;

    [Header("Configs")]
    public LocomotionConfig LocomotionConfig;
    public AttackConfig AttackConfig;
    public Item currentItem;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        References.Instance.CameraFollow.SetTarget(gameObject);
    }


    public void LockPlayer(bool value)
    {
        CharacterCommandHandler.enabled = !value;
    }

    public void PickUpItem(CollectableItem item)
    {
       // inventory.Add(item);
    }

    public Item GetCurrentItem()
    {
        return currentItem;
    }

}
