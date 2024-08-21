using TMPro;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private InventorySlotView[] _slots;
    [SerializeField] private TextMeshProUGUI _textOwner;

    public string OwnerId
    {
        get => _textOwner.text;
        set => _textOwner.SetText(value);
    }

    public InventorySlotView GetInventorySlotView(int index)
    {
        return _slots[index];
    }

}
