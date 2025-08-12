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

        private readonly float _cooldownScoreCount = 0.5f;
        private readonly int _scoreCount = 10;

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
            if (_timer >= _cooldownScoreCount)
            {
                Score += _scoreCount;
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

        private void OnDestroy()
        {
            _playerFinish.OnFinished -= StopCounting;
        }
    }
}