using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    [SerializeField] protected GameObject _interactView;

    public virtual void Focus()
    {
        _interactView.SetActive(true);
    }

    public virtual void Interact(Character character)//take info about taker
    {

    }

    public virtual void UnFocus()
    {
        _interactView.SetActive(false);
    }



}
