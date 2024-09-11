using System.Collections.Generic;
using UnityEngine;

public class SpriteHolder : MonoBehaviour
{
    [SerializeField] private List<Animator> _spriteAnimators;

    [SerializeField] private List<SpriteRenderer> _sprites;


    public List<SpriteRenderer> GetSprites()
    {
        return _sprites;
    }

    public List<Animator> GetAnimators()
    {
        return _spriteAnimators;
    }

}
