using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            LevelStarData data = _playerDataService.PlayerData.StarsByLevel
                .FirstOrDefault(starData => starData.LevelID == levelData.LevelID);
        
            return data != null ? data.StarAmount : 0;
        }
        
        public void CompleteLevel(string levelID, int stars)
        {
            var playerData = _playerDataService.PlayerData;

            // 1. Отмечаем уровень как пройденный
            if (!playerData.CompletedLevels.Contains(levelID))
            {
                playerData.CompletedLevels.Add(levelID);
            }

            // 2. Обновляем звезды
            LevelStarData existingData = playerData.StarsByLevel
                .FirstOrDefault(starData => starData.LevelID == levelID);

            if (existingData != null)
            {
                // Если запись уже есть, обновляем ее, если новый результат лучше
                if (stars > existingData.StarAmount)
                {
                    existingData.StarAmount = stars;
                }
            }
            else
            {
                // Если записи нет, создаем новую и добавляем в список
                playerData.StarsByLevel.Add(new LevelStarData { LevelID = levelID, StarAmount = stars });
            }

            _playerDataService.Save();
        }
    }
}