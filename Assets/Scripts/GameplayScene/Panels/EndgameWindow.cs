using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TestProject
{
    public class EndgameWindow : MonoBehaviour
    {
        [SerializeField] private Image _titleImage;
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _rewardText;
        [SerializeField] private Button _tapTpReturnButton;
        
        [SerializeField] private CanvasGroup _canvasGroup;

        private void Awake()
        {
            _canvasGroup.alpha = 0;
            _tapTpReturnButton.onClick.AddListener(ReturnToLevelMenu);
        }
        
        public void Show(int finalScore, PanelConfig config)
        {
            if (config == null)
            {
                return;
            }

            _titleImage.sprite= config.Title;
            _scoreText.text = finalScore.ToString();

            int reward = 0;
            if (config.CalculateReward)
            {
                reward = CountReward(finalScore);
            }
            
            _rewardText.text = reward.ToString();

            EnablePanel();
        }
        
        private void ReturnToLevelMenu()
        {
            SceneManager.LoadSceneAsync(Constants.LevelSceneName);
        }
        
        private void EnablePanel()
        {
            _canvasGroup.alpha = 1;
        }
        
        private int CountReward(int score)
        {
            int thousands = score / 1000;
            return thousands * 100;
        }
    }
}