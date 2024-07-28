using UnityEngine;

public class ButtonToggle : ButtonCustomBase
{
    [SerializeField] private UIContainerController _container;
    public override void Click()
    {
        base.Click();

        PlaySound();
        _container.Toggle();
    }

    private void PlaySound()
    {
        References.Instance.AudioHandler.PlaySound(SoundKeys.UICLICK_TYPE, SoundKeys.UICLICK);
    }
}
