using System;
using TMPro;
using UnityEngine;

public class InventorySlotView : MonoBehaviour 
{
    [SerializeField] private TextMeshProUGUI _textTitle;
    [SerializeField] private TextMeshProUGUI _textAmount;

    public string Title
    {
        get => _textTitle.text;
        set => _textTitle.SetText(value);
    }

    public int Amount
    {
        get => Convert.ToInt32(_textAmount.text);
        set => _textAmount.SetText(value == 0 ? "" : value.ToString());
    }


}
