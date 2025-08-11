using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TestProject
{
    public class LeaderboardPlayer : MonoBehaviour
    {
        [SerializeField] private TMP_Text _nameText;
        [SerializeField] private TMP_Text _scoreText;
        [SerializeField] private Image _playerIcon;
        [SerializeField] private Image _background; 

        public void Init(int rank, string playerName, int score, Sprite icon)
        {
            if (_nameText) _nameText.text = playerName;
            if (_scoreText) _scoreText.text = score.ToString();
            if (_playerIcon) _playerIcon.sprite = icon;
        }

        public void Highlight(Color highlightColor)
        {
            if (_background)
            {
                _background.color = highlightColor;
            }
        }
    }
}