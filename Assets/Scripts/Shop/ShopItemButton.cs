using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TestProject
{
    public class ShopItemButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private TMP_Text _buttonText;
        [SerializeField] private Image _skinIcon;

        private SkinData _skinData;
        private ShopManager _shopManager;
        private PlayerData _playerData; 
        
        [Inject]
        public void Construct(ShopManager shopManager, PlayerDataService playerDataService)
        {
            _shopManager = shopManager;
            _playerData = playerDataService.PlayerData;
        }
        
        private void OnEnable()
        {
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }
        
        public void SetSkinData(SkinData skinData)
        {
            _skinData = skinData;
            UpdateVisuals();
        }
        
        private void OnButtonClick()
        {
            if (!_shopManager.IsSkinPurchased(_skinData.SkinID))
            {
                _shopManager.TryBuySkin(_skinData);
            }
            else if (!_shopManager.IsSkinSelected(_skinData.SkinID))
            {
                _shopManager.SelectSkin(_skinData.SkinID);
            }
        }
        
        public void UpdateVisuals()
        {
            if (_skinData == null) return;

            _skinIcon.sprite = _skinData.SkinSprite;

            if (_shopManager.IsSkinSelected(_skinData.SkinID))
            {
                _buttonText.text = "Selected";
                _button.interactable = false;
            }
            else if (_shopManager.IsSkinPurchased(_skinData.SkinID))
            {
                _buttonText.text = "Select";
                _button.interactable = true;
            }
            else
            {
                _buttonText.text = _skinData.Price.ToString();
                _button.interactable = _shopManager.GetPlayerCoins() >= _skinData.Price;
            }
        }
    }
}