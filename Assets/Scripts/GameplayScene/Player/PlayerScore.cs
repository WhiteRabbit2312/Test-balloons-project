using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace TestProject
{
    public class PlayerScore : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private PlayerFinish _playerFinish;
        public int Score { get; private set; }
        private float _timer = 0;
        private bool _isScoreCount;

        private void Start()
        {
            _isScoreCount = true;
            _playerFinish.OnFinished += StopCounting;
            UpdateScoreText();
        }

        private void Update()
        {
            if (!_isScoreCount)
                return;
            
            _timer += Time.deltaTime;
            if (_timer >= 0.5f)
            {
                Score += 10;
                UpdateScoreText();
                _timer = 0f;
            }
        }

        private void StopCounting()
        {
            _isScoreCount = false;
        }
        
        public void Increase(int amount)
        {
            Score += amount;
            UpdateScoreText();
        }

        public void Decrease(int amount)
        {
            Score = Mathf.Max(0, Score - amount);
            UpdateScoreText();
        }

        private void UpdateScoreText()
        {
            _scoreText.text = Score.ToString();
        }
    }
}