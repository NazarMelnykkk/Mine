using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D Rigidbody2D;
    public TriggerCollider TriggerCollider;
    public CharacterAnimationController CharacterAnimationController;


    [Header("Configs")]
    public LocomotionConfig LocomotionConfig;
    public AttackConfig AttackConfig;

    public Item currentItem;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        References.Instance.CameraFollow.SetTarget(gameObject);
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
