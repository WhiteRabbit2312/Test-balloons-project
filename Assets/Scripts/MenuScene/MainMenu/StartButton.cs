using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TestProject
{
    [RequireComponent(typeof(Button))]
    public class StartButton : MonoBehaviour
    {
        private Button _startButton;
        private void Awake()
        {
            _startButton = GetComponent<Button>();
            _startButton.onClick.AddListener(StartGame);
        }

        private void OnDestroy()
        {
            _startButton.onClick.RemoveListener(StartGame);
        }

        private void StartGame()
        {
            SceneManager.LoadSceneAsync(Constants.LevelSceneName);
        }
    }
}