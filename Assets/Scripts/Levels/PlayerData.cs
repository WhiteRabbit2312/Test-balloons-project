using System.Collections.Generic;

namespace TestProject
{
    [System.Serializable]
    public class PlayerData 
    {
        public Dictionary<string, int> StarsByLevel;
        public List<string> CompletedLevels;

        public PlayerData()
        {
            StarsByLevel = new Dictionary<string, int>();
            CompletedLevels = new List<string>();
        }
    }
}