using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AlertLetter : AlertBase
{
    [SerializeField] protected Button _closeButton;

    private Coroutine _fadeInCoroutine;

    private void Awake()
    {
        _closeButton.onClick.AddListener(Disable);
    }

    protected void OnDisable()
    {
        _alertText.text = "";
        _fadeInCoroutine = null;
        _alertText.color = new Color(_alertText.color.r, _alertText.color.g, _alertText.color.b, 0f);
        _backGround.color = new Color(_backGround.color.r, _backGround.color.g, _backGround.color.b, 0f);
        _border.color = new Color(_border.color.r, _border.color.g, _border.color.b, 0f);
    }

    public void Setup(string text, string color, float delay)
    {
        _alertText.text = $"<color={color}>{text}</color>";

        if (_fadeInCoroutine != null)
        {
            StopCoroutine(_fadeInCoroutine);
        }

        gameObject.SetActive(true);
        _fadeInCoroutine = StartCoroutine(FadeIn(delay));
    }

    private IEnumerator FadeIn(float duration)
    {
        float elapsedTime = 0f;
        Color textColor = _alertText.color;
        Color bgColor = _backGround.color;
        Color borderColor = _border.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / duration);

            _alertText.color = new Color(textColor.r, textColor.g, textColor.b, alpha);
            _backGround.color = new Color(bgColor.r, bgColor.g, bgColor.b, alpha);
            _border.color = new Color(borderColor.r, borderColor.g, borderColor.b, alpha);

            yield return null;
        }

        _alertText.color = new Color(textColor.r, textColor.g, textColor.b, 1f);
        _backGround.color = new Color(bgColor.r, bgColor.g, bgColor.b, 1f);
        _border.color = new Color(borderColor.r, borderColor.g, borderColor.b, 1f);
    }

    private void Disable()
    {
        gameObject.SetActive(false);
    }
}
