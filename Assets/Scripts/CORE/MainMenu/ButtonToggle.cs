using UnityEngine;

public class ButtonToggle : ButtonCustomBase
{
    [SerializeField] private UIContainerController _container;
    public override void Click()
    {
        base.Click();

        _container.Toggle();
        PlaySound();
    }

    private void PlaySound()
    {
        DISystem.Instance.AudioHandler.PlaySound(SoundKeys.UI_Click_Type, SoundKeys.UI_Click);
    }
}
