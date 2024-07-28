using UnityEngine;

public class PauseMenuController : MonoBehaviour
{

    [SerializeField] private UIContainerController _containerSettings;


    private void Start()
    {
        References.Instance.PauseHandler.GetSettingsMenu(this);
    }

    public void TogglePauseMenu()
    {

        _containerSettings.gameObject.SetActive(!_containerSettings.gameObject.activeSelf);

    }
}
