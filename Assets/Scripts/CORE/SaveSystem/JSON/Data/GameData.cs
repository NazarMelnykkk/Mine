
[System.Serializable]
public class GameData
{
    public SoundsData SoundsData;
    public InventoriesData InventoriesData;

    public GameData()
    {
        SoundsData = new SoundsData();
        InventoriesData = new InventoriesData();
    }
}