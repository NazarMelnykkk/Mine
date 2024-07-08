using UnityEngine;

public class ButtonToggle : ButtonCustomBase
{
    [SerializeField] private UIContainerController _container;
    public override void Click()
    {
        base.Click();

        _container.Toggle();
    }
}
