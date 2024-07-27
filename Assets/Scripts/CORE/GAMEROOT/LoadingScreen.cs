using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private GameObject _loadingScreen;

    public void ToogleScreen(bool value)
    {
        _loadingScreen.SetActive(value);
    }

    
}
