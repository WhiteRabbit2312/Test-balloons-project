using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TestProject
{
    public class LoadingScreenController : MonoBehaviour
    {
        [SerializeField] private Slider _progressBar;
        [SerializeField] private string _sceneToLoad;
        [SerializeField] private float _fakeLoadingTime = 3.0f;

        private void Awake()
        {
            Application.targetFrameRate = 60;
        }

        void Start()
        {
            if (_progressBar != null)
            {
                _progressBar.value = 0;
            }

            StartCoroutine(LoadYourAsyncScene());
        }

        IEnumerator LoadYourAsyncScene()
        {
            float elapsedTime = 0f;
            while (elapsedTime < _fakeLoadingTime)
            {
                elapsedTime += Time.deltaTime;
                float progress = Mathf.Clamp01(elapsedTime / _fakeLoadingTime);

                if (_progressBar != null)
                {
                    _progressBar.value = progress;
                }

                yield return null;
            }

            if (_progressBar != null)
            {
                _progressBar.value = 1;
            }

            yield return new WaitForSeconds(0.2f);
            SceneManager.LoadScene(_sceneToLoad);
        }
    }
}