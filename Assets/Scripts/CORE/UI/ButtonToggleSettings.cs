public class ButtonToggleSettings : ButtonCustomBase
{
    
    public override void Click()
    {
        base.Click();
       
        PlaySound();

        References.Instance.PauseHandler.ToggleSetting();
    }

    private void PlaySound()
    {
        References.Instance.AudioHandler.PlaySound(SoundKeys.UI_Click_Type, SoundKeys.UI_Click);
    }
}
