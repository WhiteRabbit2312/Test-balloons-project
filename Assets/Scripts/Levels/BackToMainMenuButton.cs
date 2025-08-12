using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TestProject
{
    [RequireComponent(typeof(Button))]
    public class BackToMainMenuButton : MonoBehaviour
    {
        [SerializeField] private string _mainMenuSceneName = "MainMenuScene";
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(() => SceneManager.LoadScene(_mainMenuSceneName));
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(() => SceneManager.LoadScene(_mainMenuSceneName));
        }
    }
}