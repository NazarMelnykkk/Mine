using System.Collections;
using UnityEngine;

public class AlertPopup : AlertBase
{
    private Coroutine _lifeCoroutine;

    protected void OnDisable()
    {
        _alertText.SetText("");
        _lifeCoroutine = null;
        _alertText.color = new Color(_alertText.color.r, _alertText.color.g, _alertText.color.b, 0f);
        _backGround.color = new Color(_backGround.color.r, _backGround.color.g, _backGround.color.b, 0f);
        _border.color = new Color(_border.color.r, _border.color.g, _border.color.b, 0f);
    }

    public void Setup(string text, string color, float lifeTime, float delay)
    {
        _alertText.SetText($"<color={color}>{text}</color>");

        if (_lifeCoroutine != null)
        {
            StopCoroutine(_lifeCoroutine);
        }
        gameObject.SetActive(true);
        _lifeCoroutine = StartCoroutine(LifeCoroutine(lifeTime, delay));
    }

    private IEnumerator LifeCoroutine(float lifeTime, float delay)
    {
        yield return StartCoroutine(FadeIn(delay));

        yield return new WaitForSeconds(lifeTime);

        yield return StartCoroutine(FadeOut(delay));

        gameObject.SetActive(false);
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

    private IEnumerator FadeOut(float duration)
    {
        float elapsedTime = 0f;
        Color textColor = _alertText.color;
        Color bgColor = _backGround.color;
        Color borderColor = _border.color;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(1f - (elapsedTime / duration));

            _alertText.color = new Color(textColor.r, textColor.g, textColor.b, alpha);
            _backGround.color = new Color(bgColor.r, bgColor.g, bgColor.b, alpha);
            _border.color = new Color(borderColor.r, borderColor.g, borderColor.b, alpha);

            yield return null;
        }

        _alertText.color = new Color(textColor.r, textColor.g, textColor.b, 0f);
        _backGround.color = new Color(bgColor.r, bgColor.g, bgColor.b, 0f);
        _border.color = new Color(borderColor.r, borderColor.g, borderColor.b, 0f);

        yield return new WaitForSeconds(DelayConstants.DELAY_05);
    }


}
