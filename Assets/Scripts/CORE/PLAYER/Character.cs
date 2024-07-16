using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    [SerializeField] private List<PickableObject> inventory = new List<PickableObject>();


    private void Awake()
    {
        DISystem.Instance.CameraFollow.SetTarget(gameObject);
    }

    public void PickUpItem(PickableObject item)
    {
        inventory.Add(item);
    }
}
