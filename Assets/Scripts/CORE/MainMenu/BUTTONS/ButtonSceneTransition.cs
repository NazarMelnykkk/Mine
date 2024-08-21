using UnityEngine;

public class ButtonSceneTransition : ButtonCustomBase
{
    [SerializeField] private SceneField _sceneToTransition;
    [SerializeField] private SceneField _sceneToAdd;

    public override async void Click()
    {
        base.Click();

        await References.Instance.SceneLoader.Transition(_sceneToTransition, gameObject.scene.name);
        await References.Instance.SceneLoader.Add(_sceneToAdd);
        PlaySound();
    }

    private void PlaySound()
    {
        References.Instance.AudioHandler.PlaySound(SoundConstants.UICLICK_TYPE, SoundConstants.UICLICK);
    }
}
