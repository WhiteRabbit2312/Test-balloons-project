using System;
using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace TestProject
{
    public class ShopManager : IInitializable 
    {
        public event Action OnSkinStateChanged;
        
        private readonly PlayerDataService _playerDataService;
        private readonly List<SkinData> _allSkins;

        public ShopManager(PlayerDataService playerDataService, List<SkinData> allSkins)
        {
            _playerDataService = playerDataService;
            _allSkins = allSkins;
        }
        
        public void Initialize()
        {
            var playerData = _playerDataService.PlayerData;
            bool wasModified = false;
            
            if (!playerData.PurchasedSkinIDs.Contains(Constants.DefaultSkinID))
            {
                playerData.PurchasedSkinIDs.Add(Constants.DefaultSkinID);
                wasModified = true;
            }

            if (string.IsNullOrEmpty(playerData.SelectedSkinID) || !playerData.PurchasedSkinIDs.Contains(playerData.SelectedSkinID))
            {
                playerData.SelectedSkinID = Constants.DefaultSkinID;
                wasModified = true;
            }

            if (wasModified)
            {
                _playerDataService.Save();
                OnSkinStateChanged?.Invoke();
            }
        }

        public void SelectSkin(string skinID)
        {
            if (_playerDataService.PlayerData.PurchasedSkinIDs.Contains(skinID))
            {
                _playerDataService.PlayerData.SelectedSkinID = skinID;
                _playerDataService.Save();
                OnSkinStateChanged?.Invoke();
            }
        }
        
        public SkinData GetSelectedSkinData()
        {
            string selectedID = _playerDataService.PlayerData.SelectedSkinID;
            return _allSkins.FirstOrDefault(skin => skin.SkinID == selectedID);
        }

        public bool TryBuySkin(SkinData skinToBuy)
        {
            var playerData = _playerDataService.PlayerData;
            if (playerData.Coins >= skinToBuy.Price && !playerData.PurchasedSkinIDs.Contains(skinToBuy.SkinID))
            {
                playerData.Coins -= skinToBuy.Price;
                playerData.PurchasedSkinIDs.Add(skinToBuy.SkinID);
                SelectSkin(skinToBuy.SkinID);
                return true;
            }
            return false;
        }
        
        public bool IsSkinSelected(string skinID) => _playerDataService.PlayerData.SelectedSkinID == skinID;
        public bool IsSkinPurchased(string skinID) => _playerDataService.PlayerData.PurchasedSkinIDs.Contains(skinID);
        public int GetPlayerCoins() => _playerDataService.PlayerData.Coins;
    }
}