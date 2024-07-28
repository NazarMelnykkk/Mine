using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneTransition : ButtonCustomBase
{
    [SerializeField] private SceneField _sceneToTransition;

    public override void Click()
    {
        base.Click();

        References.Instance.SceneLoader.Transition(_sceneToTransition, gameObject.scene.name);
        PlaySound();
    }

    private void PlaySound()
    {
        References.Instance.AudioHandler.PlaySound(SoundKeys.UICLICK_TYPE, SoundKeys.UICLICK);
    }
}
