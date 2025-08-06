namespace TestProject
{
    public class UIPopup : UIWindowBase
    {
        protected override void Awake()
        {
            base.Awake();
            if (OpenButton != null)
            {
                OpenButton.onClick.AddListener(() => uiManager.OpenPopup(this));
            }
            if (CloseButton != null)
            {
                CloseButton.onClick.AddListener(() => uiManager.ClosePopup(this));
            }
        }
    }
}