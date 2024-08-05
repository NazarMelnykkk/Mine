using UnityEngine;

public class CharacterViewHolder : MonoBehaviour
{
    public InventoryController InventoryController;
    public BarUI HealthBar;

    private void Start()
    {
        Character character = GetComponent<Character>();
        character.CharacterViewHolder = this;
    }
}
