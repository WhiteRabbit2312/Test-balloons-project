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
        public int Score { get; private set; }
        private float _timer = 0;
        //public event Action<int> OnScoreChanged;

        private void Start()
        {
            UpdateScoreText();
        }

        private void Update()
        {
            _timer += Time.deltaTime;
            if (_timer >= 0.5f)
            {
                Score += 10;
                UpdateScoreText();
                _timer = 0f;
            }
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
            //OnScoreChanged?.Invoke(Score);
        }
    }
}