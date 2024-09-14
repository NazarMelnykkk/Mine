using UnityEngine;

public class References : MonoBehaviour
{
    public static References Instance;

    [field: SerializeField] public DataPersistenceHandlerBase DataPersistenceHandlerBase { get; private set; }
    [field: SerializeField] public AudioHandler AudioHandler { get; private set; }
    [field: SerializeField] public InputController InputController { get; private set; }
    [field: SerializeField] public SceneLoader SceneLoader { get; private set; }
    [field: SerializeField] public CameraFollow CameraFollow { get; private set; }
    [field: SerializeField] public CameraSnaking CameraSnaking { get; private set; }
    [field: SerializeField] public PauseHandler PauseHandler { get; private set; }
    [field: SerializeField] public WorldTime WorldTime { get; private set; }

    [Header("Links for UI")] //assign classes themselves
    [field: SerializeField] public AlertsHandler AlertsHandler;
    [field: SerializeField] public TooltipHandler TooltipHandler;

    private void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
