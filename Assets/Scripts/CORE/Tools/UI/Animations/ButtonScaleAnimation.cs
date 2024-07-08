using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScaleAnimation : ScaleAnimation
{
    protected ButtonCustomBase _customBase;

    protected void Awake()
    {
        _customBase = GetComponent<ButtonCustomBase>();
    }

    protected override void OnEnable()
    {
        _customBase.OnButtonSelectEvent += Scale;
        _customBase.OnButtonDeselectEvent += UnScale;
    }

    protected override void OnDisable()
    {
        _customBase.OnButtonSelectEvent -= Scale;
        _customBase.OnButtonDeselectEvent -= UnScale;
    }
}
