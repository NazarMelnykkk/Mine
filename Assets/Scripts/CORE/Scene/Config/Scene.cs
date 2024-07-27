[System.Serializable]
public class Scene 
{
    public string SceneName;
    public SceneField SceneField;
    public bool LoadingOnInitialization = false;
    public bool IsGameplayScene = false;
    public bool DontUnload = false;

    private void OnValidate()
    {
        if (SceneField != null)
        {
            SceneName = SceneField.SceneName;
        }
    }
}
