using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TestProject
{
    public class PauseScreen : UIScreen
    {
        [SerializeField] private Button _homeButton;

        private void Start()
        {
            _homeButton.onClick.AddListener(Home);
        }
        
        public override void Open()
        {
            base.Open();
            Time.timeScale = 0;
        }
        
        public override void Close()
        {
            base.Close();
            Time.timeScale = 1;
        }

        private void Home()
        {
            Time.timeScale = 1;
            SceneManager.LoadSceneAsync(Constants.LevelSceneName);
        }

        private void OnDestroy()
        {
            _homeButton.onClick.RemoveListener(Home);
        }
    }
}