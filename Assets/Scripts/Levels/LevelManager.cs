using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace TestProject
{
    public class LevelManager
    {
        private readonly PlayerDataService _playerDataService;
        private readonly List<LevelData> _allLevels;
        
        public LevelData CurrentLevelToLoad { get; private set; }
        
        public LevelManager(PlayerDataService playerDataService, List<LevelData> allLevels)
        {
            _playerDataService = playerDataService;
            _allLevels = allLevels;
        }
        
        public void StartLevel(LevelData levelData)
        {
            if (IsLevelUnlocked(levelData))
            {
                CurrentLevelToLoad = levelData;
                SceneManager.LoadSceneAsync(Constants.GameplaySceneName);
            }
        }
        
        public bool IsLevelUnlocked(LevelData levelData)
        {
            if (levelData.PrerequisiteLevel == null)
            {
                return true;
            }
            
            return _playerDataService.PlayerData.CompletedLevels.Contains(levelData.PrerequisiteLevel.LevelID);
        }
        
        public int GetStars(LevelData levelData)
        {
            _playerDataService.PlayerData.StarsByLevel.TryGetValue(levelData.LevelID, out int stars);
            return stars;
        }
        
        public void CompleteLevel(string levelID, int stars)
        {
            var playerData = _playerDataService.PlayerData;

            if (!playerData.CompletedLevels.Contains(levelID))
            {
                playerData.CompletedLevels.Add(levelID);
            }

            if (!playerData.StarsByLevel.TryGetValue(levelID, out int currentStars) || stars > currentStars)
            {
                playerData.StarsByLevel[levelID] = stars;
            }

            _playerDataService.Save();
        }
    }
}