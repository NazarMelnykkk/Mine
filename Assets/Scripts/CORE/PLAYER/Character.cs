using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    [SerializeField] private List<CollectableItem> inventory = new List<CollectableItem>();


    private void Awake()
    {
        References.Instance.CameraFollow.SetTarget(gameObject);
    }

    public void PickUpItem(CollectableItem item)
    {
        inventory.Add(item);
    }

}
