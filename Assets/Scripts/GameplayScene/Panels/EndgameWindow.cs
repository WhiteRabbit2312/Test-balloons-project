using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace TestProject
{
    public class EndgameWindow : MonoBehaviour
    {
        [SerializeField] private Image _titleImage;
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private TMP_Text _rewardText;
        [SerializeField] private Button _tapTpReturnButton;
        
        [SerializeField] private CanvasGroup _canvasGroup;

        private PlayerDataService _playerDataService;
        
        [Inject]
        public void Construct(PlayerDataService playerDataService)
        {
            _playerDataService = playerDataService;
        }

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

            _playerDataService.PlayerData.Coins += finalScore;
            
            int reward = 0;
            if (config.CalculateReward)
            {
                reward = CountReward(finalScore);
                _playerDataService.PlayerData.Coins += reward;
            }
            _playerDataService.Save();
            
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
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.ignoreParentGroups = true;
        }
        
        private int CountReward(int score)
        {
            int thousands = score / 100;
            return thousands * 100;
        }
    }
}