using System.Collections.Generic;

namespace TestProject
{
    [System.Serializable]
    public class PlayerData 
    {
        public List<LevelStarData> StarsByLevel;
        public List<string> CompletedLevels;
        
        public List<string> PurchasedSkinIDs;
        public string SelectedSkinID;

        public int Coins;
        public int Score;

        public PlayerData()
        {
            Coins = 1000;
            Score = 0;
            StarsByLevel = new List<LevelStarData>();
            CompletedLevels = new List<string>();
            PurchasedSkinIDs = new List<string>
            {
                "default_skin"
            };
            SelectedSkinID = "default_skin"; 
        }
    }
    
    [System.Serializable]
    public class LevelStarData
    {
        public string LevelID;
        public int StarAmount;
    }
}