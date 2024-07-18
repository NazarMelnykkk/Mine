using UnityEngine;
using UnityEngine.UI;

public class BarObject : BarBase
{
    [SerializeField] private Image _barImage;

    public override void UpdateBar(int maxValue, int currentValue)
    {
        float fillAmount = (float)currentValue / (float)maxValue;
        _barImage.fillAmount = fillAmount;

    }
}
