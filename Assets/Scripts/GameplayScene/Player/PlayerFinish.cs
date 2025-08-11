using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace TestProject
{
    public class PlayerFinish : MonoBehaviour
    {
        [SerializeField] private GameObject _finishWindow;
        [SerializeField] private EndgameWindow _endgameWindow;
        [SerializeField] private PlayerScore _playerScore;
        [SerializeField] private PanelConfig _panelConfig;
        public event Action OnFinished;
        
        private CollectableContainer _collectableContainer;
        private LevelManager _levelManager;
        
        [Inject]
        public void Construct(LevelManager levelManager, CollectableContainer collectableContainer)
        {
            _levelManager = levelManager;
            _collectableContainer = collectableContainer;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Constants.FinishTag))
            {
                _levelManager.CompleteLevel(_collectableContainer.StarQuantity);
                StartCoroutine(EnablePanel());
            }
        }

        private IEnumerator EnablePanel()
        {
            _finishWindow.SetActive(true);
            yield return new WaitForSeconds(1f);
            _finishWindow.SetActive(false);
            _endgameWindow.Show(_playerScore.Score, _panelConfig);
            OnFinished?.Invoke();
        }
    }
}