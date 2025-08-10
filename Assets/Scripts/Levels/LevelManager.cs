using System.Linq;
using UnityEngine.SceneManagement;

namespace TestProject
{
    public class LevelManager
    {
        private readonly PlayerDataService _playerDataService;
        
        public LevelData CurrentLevelToLoad { get; private set; }
        
        public LevelManager(PlayerDataService playerDataService)
        {
            _playerDataService = playerDataService;
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
        
        public void CompleteLevel(int stars)
        {
            var playerData = _playerDataService.PlayerData;

            if (!playerData.CompletedLevels.Contains(CurrentLevelToLoad.LevelID))
            {
                playerData.CompletedLevels.Add(CurrentLevelToLoad.LevelID);
            }

            LevelStarData existingData = playerData.StarsByLevel
                .FirstOrDefault(starData => starData.LevelID == CurrentLevelToLoad.LevelID);

            if (existingData != null)
            {
                if (stars > existingData.StarAmount)
                {
                    existingData.StarAmount = stars;
                }
            }
            else
            {
                playerData.StarsByLevel.Add(new LevelStarData { LevelID = CurrentLevelToLoad.LevelID, StarAmount = stars });
            }

            _playerDataService.Save();
        }
    }
}