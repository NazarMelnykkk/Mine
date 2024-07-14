using System.Collections;
using TMPro;
using UnityEngine;

public class TooltipHandler : MonoBehaviour
{

    [SerializeField] private RectTransform _backGroundRectTransformBox;
    [SerializeField] private TextMeshProUGUI _TooltipText;

    [Header("TooltipBox Configurations")]
    [SerializeField] private float _paddingSize = 5f;

    private Coroutine _updatePosition;

    public void Show(string text)
    {
        _TooltipText.text = text;

        if (_updatePosition == null) 
        {
            _updatePosition = StartCoroutine(UpdatePosition());
        }
    }

    public void Hide()
    {
        if (_updatePosition != null)
        {
            StopCoroutine(_updatePosition);
            _updatePosition = null;
        }

        _backGroundRectTransformBox.gameObject.SetActive(false);
        _TooltipText.text = null;
    }

    private IEnumerator UpdatePosition()
    {
        while (true)
        {
            Vector2 tooltipPosition = Input.mousePosition;

            float tooltipWidth = _backGroundRectTransformBox.sizeDelta.x;
            float tooltipHeight = _backGroundRectTransformBox.sizeDelta.y;

            float maxX = Screen.width - tooltipWidth;
            float maxY = Screen.height - tooltipHeight;

            tooltipPosition.x = Mathf.Clamp(tooltipPosition.x, 0, maxX - _paddingSize);
            tooltipPosition.y = Mathf.Clamp(tooltipPosition.y, 0, maxY - _paddingSize);

            _backGroundRectTransformBox.gameObject.transform.position = tooltipPosition;

            _backGroundRectTransformBox.gameObject.SetActive(true);

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
}