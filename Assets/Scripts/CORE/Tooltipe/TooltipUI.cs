using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class TooltipUI : TooltipBase, IPointerEnterHandler, IPointerExitHandler
{
    private bool _isShowing = false;
    private string _information;
    private Coroutine _showDelayCoroutine;

    public virtual void OnPointerEnter(PointerEventData eventData)
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

    public virtual void OnPointerExit(PointerEventData eventData)
    {
        UnFocus();
    }

    public override void UnFocus()
    {
        if (_showDelayCoroutine != null)
        {
            StopCoroutine(_showDelayCoroutine);
            References.Instance.TooltipHandler.Hide();
            _showDelayCoroutine = null;
            _isShowing = false;
        }
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
                References.Instance.TooltipHandler.Show(_information);
            }
            yield break;
        }
    }

    protected override void OnDisable()
    {
        _information = null;
        References.Instance.TooltipHandler.Hide();
    }
}
