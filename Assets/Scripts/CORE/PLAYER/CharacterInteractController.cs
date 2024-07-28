using System.Collections;
using UnityEngine;

public class CharacterInteractController : MonoBehaviour
{
    [SerializeField] private LayerMask _targetLayer;
    private IInteractable _currentlyHovered;

    [SerializeField] private Character _character;
    [SerializeField] private Collider2D _collider;

    private void OnEnable()
    {
        References.Instance.InputController.OnInteractionPerformedEvent += Interact;
    }

    private void OnDisable()
    {
        References.Instance.InputController.OnInteractionPerformedEvent -= Interact;
    }

    private void Interact()
    {
        if (_currentlyHovered != null)
        {
            _currentlyHovered.Interact(_character);
            StartCoroutine(ReEnableTrigger());
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

    private IEnumerator ReEnableTrigger()
    {
        _collider.enabled = false;
        yield return new WaitForEndOfFrame(); 
        _collider.enabled = true;
    }
}