using UnityEngine;

public class CharacterInteractController : MonoBehaviour
{
    [SerializeField] private LayerMask _targetLayer;
    private IInteractable _currentlyHovered;

    [SerializeField] private Character _character;

    private void OnEnable()
    {
        DISystem.Instance.InputController.OnInteractionPerformedEvent += Interact;
    }

    private void OnDisable()
    {
        DISystem.Instance.InputController.OnInteractionPerformedEvent -= Interact;
    }

    private void Interact()
    {
        if (_currentlyHovered != null)
        {
            _currentlyHovered.Interact(_character);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (_currentlyHovered == null)
        {
            if (((1 << collision.gameObject.layer) & _targetLayer) != 0)
            {
                _currentlyHovered = collision.GetComponent<InteractableObject>();
                if (_currentlyHovered != null)
                {
                    _currentlyHovered.Focus();
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (_currentlyHovered != null && collision.transform == (_currentlyHovered as MonoBehaviour).transform)
        {
            _currentlyHovered.UnFocus();
            _currentlyHovered = null;
        }
    }
}