[System.Serializable]

public class InventoriesData
{

    public SerializableDictionary<string, InventoryGridData> InventoriesGridData;

    public InventoriesData()
    {
        InventoriesGridData = new SerializableDictionary<string, InventoryGridData>();
    }   
}
