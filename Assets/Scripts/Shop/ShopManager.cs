using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TestProject
{
    public class ShopManager
    {
        private readonly PlayerDataService _playerDataService;
        private readonly List<SkinData> _allSkins;

        public ShopManager(PlayerDataService playerDataService, List<SkinData> allSkins)
        {
            _playerDataService = playerDataService;
            _allSkins = allSkins;

            if (!_playerDataService.PlayerData.PurchasedSkinIDs.Contains("default_skin"))
            {
                _playerDataService.PlayerData.PurchasedSkinIDs.Add("default_skin");
                _playerDataService.Save();
            }
        }

        public void SelectSkin(string skinID)
        {
            if (_playerDataService.PlayerData.PurchasedSkinIDs.Contains(skinID))
            {
                _playerDataService.PlayerData.SelectedSkinID = skinID;
                _playerDataService.Save();
            }
        }
        
        public SkinData GetSelectedSkinData()
        {
            string selectedID = _playerDataService.PlayerData.SelectedSkinID;
            return _allSkins.FirstOrDefault(skin => skin.SkinID == selectedID);
        }

        public bool TryBuySkin(SkinData skinToBuy)
        {
            return false;
        }
    }
}