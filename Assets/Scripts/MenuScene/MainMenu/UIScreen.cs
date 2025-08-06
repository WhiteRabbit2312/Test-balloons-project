namespace TestProject
{
    public abstract class UIScreen : UIWindowBase
    {
        protected override void Awake()
        {
            base.Awake();
            if (OpenButton != null)
            {
                OpenButton.onClick.AddListener(() => UiManager.OpenScreen(this));
            }
            if (CloseButton != null)
            {
                CloseButton.onClick.AddListener(() => UiManager.CloseScreen(this));
            }
        }
    }
}