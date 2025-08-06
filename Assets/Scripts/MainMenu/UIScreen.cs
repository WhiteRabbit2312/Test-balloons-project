namespace TestProject
{
    public class UIScreen : UIWindowBase
    {
        protected override void Awake()
        {
            base.Awake();
            if (OpenButton != null)
            {
                OpenButton.onClick.AddListener(() => uiManager.OpenScreen(this));
            }
            if (CloseButton != null)
            {
                CloseButton.onClick.AddListener(() => uiManager.CloseScreen(this));
            }
        }
    }
}