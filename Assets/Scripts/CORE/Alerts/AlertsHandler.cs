using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertsHandler : MonoBehaviour
{
    [SerializeField] private AlertPopup alertPopup;
    [SerializeField] private List<AlertBase> _alerts = new List<AlertBase>();
    public bool IsAnyAlertOn()
    {
        return transform.childCount > 0;
    }

    public void DisableAlerts()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }

    public void DisplayAlert(string alertMsg, float speed = 1, int sortOrder = 3, float delay = 0)
    {
        DisableAlerts();

        StopAllCoroutines();
        StartCoroutine(CreateAlertCoroutine(alertMsg, speed, sortOrder, delay));
    }

    private IEnumerator CreateAlertCoroutine(string alertMsg, float speed = 1, int sortOrder = 3, float delay = 0)
    {
        if (delay > 0)
            yield return new WaitForSeconds(delay);

        AlertPopup newAlert = Instantiate(alertPopup, transform);
        newAlert.gameObject.SetActive(true);
        newAlert.SetText(alertMsg);
    }
}
