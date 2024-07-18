using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BarUI : BarBase
{
    [SerializeField] protected Slider _currentBar;

    public override void UpdateBar(int maxValue, int currentValue)
    {
        _currentBar.maxValue = maxValue;
        _currentBar.minValue = 0;
        _currentBar.value = currentValue;
    }
}
