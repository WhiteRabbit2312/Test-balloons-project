using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TestProject
{
    public class BuyPopUp : UIPopup
    {
        [Header("BuyPopUp")]
        [SerializeField] private Button _buyButton;
        [SerializeField] private Button _cancelButton;
        [SerializeField] private Image _itemImg;
        private SkinData _skinData;
        private ShopManager _shopManager;

        [Inject]
        public void Construct(ShopManager shopManager)
        {
            _shopManager = shopManager;
        }

        protected override void Awake()
        {
            base.Awake();
            _buyButton.onClick.AddListener(Buy);
            _cancelButton.onClick.AddListener(Close);
        }

        public override void Open()
        {
            base.Open();
            _itemImg.sprite = _skinData.SkinSprite;
        }
        
        public void Init(SkinData skinData)
        {
            _skinData = skinData;
        }

        private void Buy()
        {
            if (_shopManager.TryBuySkin(_skinData))
            {
                Close();
            }
        }
    }
}