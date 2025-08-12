using System;

namespace TestProject
{
    public abstract class UIPopup : UIWindowBase
    {
        protected override void Awake()
        {
            base.Awake();
            if (OpenButton != null)
            {
                OpenButton.onClick.AddListener(() => UiManager.OpenPopup(this));
            }
            if (CloseButton != null)
            {
                CloseButton.onClick.AddListener(() => UiManager.ClosePopup(this));
            }
        }

        private void OnDestroy()
        {
            if (OpenButton != null)
            {
                OpenButton.onClick.RemoveListener(() => UiManager.OpenPopup(this));
            }
            if (CloseButton != null)
            {
                CloseButton.onClick.RemoveListener(() => UiManager.ClosePopup(this));
            }
        }
    }
}