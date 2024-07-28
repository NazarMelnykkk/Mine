using System.Collections;
using UnityEngine;

public class CollectableItem : InteractableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private int itemQuantity;
    [SerializeField] private Collider2D _collectableCollider;

    private Coroutine _collectCoroutine; 
    private Character _character;
    private float _moveSpeed = 5f;


    /* public override void Interact(Character character)
     {
         base.Interact(character);
         character.PickUpItem(this);
         gameObject.SetActive(false);
     }*/

    public override void Interact(Character character)
    {
        base.Interact(character);
        if (_collectCoroutine == null)
        {
            _character = character;
            _collectableCollider.enabled = false;
            UnFocus();
            _collectCoroutine = StartCoroutine(UpdateMoveToCollectableTarget());
        }
    }

    private IEnumerator UpdateMoveToCollectableTarget()
    {
        while (Vector3.Distance(transform.position, _character.transform.position) > 0.1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _character.transform.position, _moveSpeed * Time.deltaTime);
            yield return null;
        }
        PlaySound();
        _character.PickUpItem(this);
        gameObject.SetActive(false);
        _collectCoroutine = null;
    }

    public string GetItemName()
    {
        return itemName;
    }

    public int GetItemQuantity()
    {
        return itemQuantity;
    }

    private void PlaySound()
    {
        References.Instance.AudioHandler.PlaySound(SoundKeys.COLLECTITEM_TYPE, SoundKeys.COLLECTITEM);
    }
}
