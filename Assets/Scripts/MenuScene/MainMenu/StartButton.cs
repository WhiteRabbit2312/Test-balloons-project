using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TestProject
{
    [RequireComponent(typeof(Button))]
    public class StartButton : MonoBehaviour
    {
        [SerializeField] private GameObject _balloons;
        private Button _startButton;
        private void Awake()
        {
            _startButton = GetComponent<Button>();
            _startButton.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            SpawnTransition();
            SceneManager.LoadSceneAsync(Constants.LevelSceneName);
        }

        private void SpawnTransition()
        {
            //Instantiate(_balloons, transform.position, Quaternion.identity);
        }
    }
}