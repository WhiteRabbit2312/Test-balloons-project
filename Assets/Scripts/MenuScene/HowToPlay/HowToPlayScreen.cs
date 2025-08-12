using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TestProject
{
    public class HowToPlayScreen : UIScreen
    {
        [Header("How to Play")] [SerializeField]
        private Button _okButton;

        protected override void Awake()
        {
            base.Awake();
            _okButton.onClick.AddListener(Close);
        }
    }
}