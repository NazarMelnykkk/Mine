using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] protected SpriteHolder SpriteHolder;

    public virtual void Idle()
    {
        foreach (Animator animator in SpriteHolder.GetAnimators())
        {
            animator.SetBool("IsWalking", false);
        }
    }

    public virtual void Move(Vector2 direction)
    {
        foreach (Animator animator in SpriteHolder.GetAnimators())
        {
            animator.SetFloat("Vertical", direction.y);
            animator.SetFloat("Horizontal", direction.x);

            animator.SetBool("IsWalking", true);
        }
    }

    public virtual void Attack()
    {
        foreach (Animator animator in SpriteHolder.GetAnimators())
        {
            animator.SetTrigger("Attack");
        }
    }

    public virtual void Death()
    {
        foreach (Animator animator in SpriteHolder.GetAnimators())
        {
            animator.SetTrigger("Death");
        }
    }
}
