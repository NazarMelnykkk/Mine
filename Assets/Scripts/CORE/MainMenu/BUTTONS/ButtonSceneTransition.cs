using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonSceneTransition : ButtonCustomBase
{
    [SerializeField] private SceneField _sceneToTransition;
    [SerializeField] private SceneField _sceneToAdd;

    public override void Click()
    {
        base.Click();

        References.Instance.SceneLoader.Transition(_sceneToTransition, gameObject.scene.name);
        References.Instance.SceneLoader.Add(_sceneToAdd);
        PlaySound();
    }

    private void PlaySound()
    {
        References.Instance.AudioHandler.PlaySound(SoundKeys.UICLICK_TYPE, SoundKeys.UICLICK);
    }
}
