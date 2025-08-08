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
        private int _score = 0;

        private void Awake()
        {
            
        }

        private void Update()
        {
            
        }
        
        public void Increase(int score)
        {
            _score += score;
        }

        public void Decrease(int score)
        {
            _score -= score;
        }
    }
}