using System;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class WorldLight : MonoBehaviour
{
    [SerializeField] private Light2D _light;

    [SerializeField] private WorldTime _worldTime;
    [SerializeField] private Gradient _gradient;

    private void Start()
    {
        _worldTime.WorldTimeChanged += OnWorldTimeChanged;
    }

    private void OnDestroy()
    {
        _worldTime.WorldTimeChanged -= OnWorldTimeChanged;
    }

    private void OnWorldTimeChanged(object sender , TimeSpan newTime)
    {
        _light.color = _gradient.Evaluate(PercentOfDay(newTime));
    }

    private float PercentOfDay(TimeSpan timeSpan)
    {
        return (float)timeSpan.TotalMinutes % WorldTimeConstants.MINUTES_IN_DAY / WorldTimeConstants.MINUTES_IN_DAY;
    }


}
