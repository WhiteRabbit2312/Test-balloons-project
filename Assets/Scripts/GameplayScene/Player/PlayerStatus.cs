using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TestProject
{
    public class PlayerStatus : MonoBehaviour
    {
        [Header("Lose fields")]
        [SerializeField] private EndgameWindow _endgameWindow;

        [SerializeField] private PanelConfig _panelConfig;
        
        [Space]
        [Header("Health fields")]
        [SerializeField] private Slider _healthSlider;
        private int _currentHealth;
        private const int MaxHealth = 10;

        [Space]
        [SerializeField] private PlayerScore _playerScore;
        private void Awake()
        {
            _healthSlider.maxValue = MaxHealth;
            _healthSlider.value = MaxHealth;
            _currentHealth = MaxHealth;
        }

        public void IncreaseHealth(int amount)
        {
            if (_currentHealth < MaxHealth)
            {
                _currentHealth += amount;
            }
            UpdateHealthBar();
        }

        public void DecreaseHealth(int amount)
        {
            _currentHealth -= amount;
            UpdateHealthBar();
            if (_currentHealth <= 0)
            {
                _endgameWindow.Show(_playerScore.Score, _panelConfig);
            }
        }

        private void UpdateHealthBar()
        {
            _healthSlider.value = _currentHealth;
        }
    }
}