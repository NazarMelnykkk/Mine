using TMPro;
using UnityEngine;

public class AlertBase : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI _alertText;
    [SerializeField] protected bool _isShowing = false;


    public void SetText(string text)
    {
        _alertText.text = text;
    }

    protected void EnableAnimation()
    {

    }

    protected void DisableAnimation()
    {

    }

    protected void OnEnable()
    {
        _isShowing = true;
    }

    protected void OnDisable()
    {
        _isShowing = false;
        _alertText.text = "";
    }

}
