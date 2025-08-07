using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TestProject
{
    public class LoadingScreenController : MonoBehaviour
    {
        [SerializeField] private Slider _progressBar;

        [SerializeField] private string _sceneToLoad = "MainMenuScene";

        void Start()
        {
            StartCoroutine(LoadSceneAsync());
        }

        private IEnumerator LoadSceneAsync()
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(_sceneToLoad);
            operation.allowSceneActivation = false;
            while (!operation.isDone)
            {
                float progress = Mathf.Clamp01(operation.progress / 0.9f);
                _progressBar.value = Mathf.MoveTowards(_progressBar.value, progress, Time.deltaTime);

                if (operation.progress >= 0.9f && _progressBar.value >= 0.99f)
                {
                    _progressBar.value = 1f;

                    operation.allowSceneActivation = true;
                }

                yield return null;
            }
        }
    }
}