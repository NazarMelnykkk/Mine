using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundController : MonoBehaviour
{
    [SerializeField] private List<ButtonCustomBase> _sounds;

    private void OnEnable()
    {
        foreach (var sound in _sounds)
        {
            sound.OnButtonClickEvent += PlaySound;
        }
    }

    private void OnDisable()
    {
        foreach (var sound in _sounds)
        {
            sound.OnButtonClickEvent -= PlaySound;
        }
    }
    private void PlaySound()
    {
        SystemLinkHolder.Instance.AudioHandler.PlaySound(SoundKeys.UI_Click_Type, SoundKeys.UI_Click);
    }
}
