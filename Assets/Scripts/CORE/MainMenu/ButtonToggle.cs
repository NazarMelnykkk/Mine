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
        References.Instance.AudioHandler.PlaySound(SoundKeys.UI_Click_Type, SoundKeys.UI_Click);
    }
}
