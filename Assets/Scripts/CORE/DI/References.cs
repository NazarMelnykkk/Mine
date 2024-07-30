using UnityEngine;

public class References : MonoBehaviour
{
    public static References Instance;

    [Header("Links System")]
    public DataPersistenceHandlerBase DataPersistenceHandlerBase;
    public AudioHandler AudioHandler;
    public InputController InputController;
    public SceneLoader SceneLoader;
    public CameraFollow CameraFollow;
    public CameraSnaking CameraSnaking;
    public PauseHandler PauseHandler;

    [Header("Links UI")]
    public AlertsHandler AlertsHandler;
    public TooltipHandler TooltipHandler;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("DESCTORY");
            Destroy(gameObject);
        }

        Debug.Log("ITIN");
    }
}
