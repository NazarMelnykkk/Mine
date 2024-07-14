using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipBase : MonoBehaviour
{

    protected virtual void Awake()
    {

    }

    public virtual void Focus()
    {

    }

    public virtual void UnFocus()
    {

    }

    protected virtual void CheckItem()
    {

    }

    protected virtual void CreateText()
    {

    }

    protected virtual IEnumerator ShowDelay()
    {


        while (true)
        {
            yield break;
        }
    }

    protected virtual void OnDisable()
    {

    }
}
