using System.Collections;
using UnityEngine;

public class TooltipObject : TooltipBase
{
    private Coroutine _showDelayCoroutine;
    [SerializeField] private bool _isShowing = false;
    private string _information;

    public virtual void OnMouseEnter()
    {
        Focus();
    }

    public override void Focus()
    {
        if (_isShowing == false)
        {
            _isShowing = true;
            Debug.Log("ENTER");
            CreateText("asdsadsad " +
                "asdasd " +
                "asdas " +
                "asd");
        }
    }

    public virtual void OnMouseExit()
    {
        UnFocus();
    }

    public override void UnFocus()
    {
        if (_showDelayCoroutine != null)
        {
            StopCoroutine(_showDelayCoroutine);
            DISystem.Instance.TooltipHandler.Hide();
            _showDelayCoroutine = null;
            _isShowing = false;
        }
        _isShowing = false;
    }

    private void CreateText(string tooltipeText)
    {
        if (tooltipeText == "")
        {
            return;
        }

        if (_information == null)
        {
            _information = tooltipeText;
        }

        if (_showDelayCoroutine == null)
        {
            _showDelayCoroutine = StartCoroutine(ShowDelay());
        }
    }

    protected override IEnumerator ShowDelay()
    {
        yield return new WaitForSeconds(KeysDelay.DELAY_05);

        while (true)
        {
            if (_isShowing == true)
            {
                DISystem.Instance.TooltipHandler.Show(_information);
            }
            yield break;
        }
    }

    protected override void OnDisable()
    {
        _information = null;
        DISystem.Instance.TooltipHandler.Hide();
    }
}
