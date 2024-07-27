using System.Collections.Generic;
using UnityEngine;

public class SpriteHolder : MonoBehaviour
{
    [SerializeField] private List<Animator> Animators;

    public List<Animator> GetAnimators()
    {
        return Animators;
    }

}
