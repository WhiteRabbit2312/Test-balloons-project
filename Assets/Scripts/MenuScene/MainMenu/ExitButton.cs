using UnityEngine;
using UnityEngine.UI;

namespace TestProject
{
    [RequireComponent(typeof(Button))]
    public class ExitButton : MonoBehaviour
    {
        private Button _button;
        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(ExitGame);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(ExitGame);
        }

        private void ExitGame()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}