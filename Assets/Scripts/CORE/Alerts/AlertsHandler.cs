using System.Collections.Generic;
using UnityEngine;


public enum AlertType
{
    Letter = 0,
    Popup = 1,
}

public class AlertsHandler : MonoBehaviour
{

    [Header("Letter")]
    [SerializeField] private List<AlertLetter> _alertsLetters = new List<AlertLetter>();
    [SerializeField] private AlertLetter _alertLetterPrefab;
    [SerializeField] private GameObject _letterHolder;
    private int _letterIndex = 0;

    [Header("Popup")]
    [SerializeField] private List<AlertPopup> _alertsPopup = new List<AlertPopup>();
    [SerializeField] private AlertPopup _alertPopupPrefab;
    [SerializeField] private GameObject _popupHolder;
    private int _popupIndex = 0;

    private void Awake()
    {
        References.Instance.AlertsHandler = this;
    }

    private void Start()
    {
       /* AlertLetter("iasdasd asdasd as" +
            " asdas d" +
            " asd" +
            "asd " +
            "as" +
            "d as" +
            "d ", KeysColor.RED, 1);*/
    }

    /*private void Awake()
    {
        for (int i = 0; i < 7; i++)
        {
            AlertPopup("i " + i, KeysColor.ORANGE, i, 1);
            AlertLetter("i " + i, KeysColor.RED, 1);
        }      
    }*/

    public void AlertLetter(string text, string color = ColorConstants.DEFAULT, float delay = 1)
    {
        if (_letterIndex >= _alertsLetters.Count) 
        {
            _letterIndex = 0;
        }

        if (_alertsLetters[_letterIndex].gameObject.activeSelf == true)
        {
            AlertLetter newItem = CreateNewLetter();
            _alertsLetters.Add(newItem);

            _letterIndex = _alertsLetters.Count - 1;
        }

        _alertsLetters[_letterIndex].transform.SetAsLastSibling();

        _alertsLetters[_letterIndex].Setup(text, color, delay);

        _letterIndex++;
    }

    public void AlertPopup(string text, string color = ColorConstants.DEFAULT, float lifeTime = 1, float delay = 1)
    {
        if (_popupIndex >= _alertsPopup.Count)
        {
            _popupIndex = 0;
        }

        if (_alertsPopup[_popupIndex].gameObject.activeSelf == true)
        {
            AlertPopup newItem = CreateNewPopup();
            _alertsPopup.Add(newItem);

            _popupIndex = _alertsPopup.Count - 1;
        }

        _alertsPopup[_popupIndex].transform.SetAsFirstSibling();

        _alertsPopup[_popupIndex].Setup(text, color, lifeTime, delay);

        _popupIndex++;
    }


    public void DisableAlerts()
    {
        foreach (AlertLetter alert in _alertsLetters)
        {
            alert.gameObject.SetActive(false);
        }

        foreach (AlertPopup alert in _alertsPopup)
        {
            alert.gameObject.SetActive(false);
        }

        ResetSettings();
    }

    private AlertLetter CreateNewLetter()
    {
        AlertLetter newItem = Instantiate(_alertLetterPrefab);
        newItem.gameObject.SetActive(false);
        newItem.transform.SetParent(_letterHolder.transform, false);

        return newItem;
    }

    private AlertPopup CreateNewPopup()
    {
        AlertPopup newItem = Instantiate(_alertPopupPrefab);
        newItem.gameObject.SetActive(false);
        newItem.transform.SetParent(_popupHolder.transform, false);

        return newItem;
    }


    private void ResetSettings()
    {
        _letterIndex = 0;
        _popupIndex = 0;
    }

}
