using UnityEngine;

public class DISystem : MonoBehaviour
{
    public static DISystem Instance;

    [Header("Links")]
    public DataPersistenceHandlerBase DataPersistenceHandlerBase;
    public AudioHandler AudioHandler;
    public InputController InputController;
    public SceneLoader SceneLoader;
    public AlertsHandler AlertsHandler;
    public TooltipHandler TooltipHandler;
    public CameraFollow CameraFollow;
    public CameraSnaking CameraSnaking;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        Application.targetFrameRate = 60;
    }
}
