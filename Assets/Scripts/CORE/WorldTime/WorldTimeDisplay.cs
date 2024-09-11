using System;
using TMPro;
using UnityEngine;

public class WorldTimeDisplay : MonoBehaviour
{
    [SerializeField] private WorldTime _worldTime;
    [SerializeField] private TextMeshProUGUI _text;

    private void Awake()
    {
        _worldTime = References.Instance.WorldTime;
        _worldTime.WorldTimeChanged += OnWorldTimeChanged;
    }

    private void OnDestroy()
    {
        _worldTime.WorldTimeChanged -= OnWorldTimeChanged;
    }

    private void OnWorldTimeChanged(object sender, TimeSpan newTime)
    {
        _text.SetText(newTime.ToString(@"hh\:mm"));
    }
}
