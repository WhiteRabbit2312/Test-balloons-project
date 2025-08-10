using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    public class PlayerFinish : MonoBehaviour
    {
        [SerializeField] private GameObject _finishWindow;
        [SerializeField] private EndgameWindow _endgameWindow;
        [SerializeField] private PlayerScore _playerScore;
        [SerializeField] private PanelConfig _panelConfig;
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Constants.FinishTag))
            {
                StartCoroutine(EnablePanel());
            }
        }

        private IEnumerator EnablePanel()
        {
            _finishWindow.SetActive(true);
            yield return new WaitForSeconds(1f);
            _finishWindow.SetActive(false);
            _endgameWindow.Show(_playerScore.Score, _panelConfig);
            Time.timeScale = 0f;
        }
    }
}