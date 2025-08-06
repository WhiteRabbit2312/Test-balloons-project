using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Zenject;

namespace TestProject
{
    public abstract class UIWindowBase : MonoBehaviour
    {
        [SerializeField] private GameObject _mainMenuWindow;
        [SerializeField] protected CanvasGroup Window;
        [SerializeField] protected Button OpenButton;
        [SerializeField] protected Button CloseButton;

        [Inject] protected UIManager UiManager;

        protected virtual void Awake()
        {
            if (Window == null)
            {
                Window = this.GetComponent<CanvasGroup>();
            }
        }

        public virtual void Open()
        {
            Debug.Log("Open");
            _mainMenuWindow.SetActive(false);
            
            Window.alpha = 1f;
            Window.interactable = true;
            Window.blocksRaycasts = true;
        }

        public virtual void Close()
        {
            Debug.Log("Close");
            _mainMenuWindow.SetActive(true);
            Window.alpha = 0f;
            Window.interactable = false;
            Window.blocksRaycasts = false;
        }
    }
}