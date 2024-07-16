using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] protected Animator Animator;

    public virtual void Idle()
    {
        Animator.SetBool("IsWalking", false);
    }

    public virtual void Move(Vector2 direction)
    {
        Animator.SetFloat("Vertical", direction.y);
        Animator.SetFloat("Horizontal", direction.x);

        Animator.SetBool("IsWalking", true);
    }
}
