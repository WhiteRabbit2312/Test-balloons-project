using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace TestProject
{
    public class UIWindowBase : MonoBehaviour
    {
        [SerializeField] protected CanvasGroup Window;
        [SerializeField] protected Button OpenButton;
        [SerializeField] protected Button CloseButton;

        [Inject] protected UIManager uiManager;

        protected virtual void Awake()
        {
            if (Window == null)
            {
                Window = this.GetComponent<CanvasGroup>();
            }
        }

        public virtual void Open()
        {
            Window.alpha = 1f;
            Window.interactable = true;
            Window.blocksRaycasts = true;
        }

        public virtual void Close()
        {
            Window.alpha = 0f;
            Window.interactable = false;
            Window.blocksRaycasts = false;
        }
    }
}