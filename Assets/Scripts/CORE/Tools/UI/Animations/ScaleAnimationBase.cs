using DG.Tweening;
using UnityEngine;

public class ScaleAnimationBase : MonoBehaviour
{
    protected float _scaleFactor = 1.2f;

    protected Vector3 originalScale = new Vector3(1, 1, 1);
    protected Coroutine _animateScaleCoroutine;
}
