using System.IO;
using UnityEngine;

namespace TestProject
{
    public class PlayerDataService
    {
        public PlayerData PlayerData { get; private set; }

        private static readonly string saveFileName = "playerdata.json";

        public PlayerDataService()
        {
            Load();
        }

        private string GetPath()
        {
            return Path.Combine(Application.persistentDataPath, saveFileName);
        }

        public void Save()
        {
            string json = JsonUtility.ToJson(PlayerData, true);
            File.WriteAllText(GetPath(), json);
        }

        private void Load()
        {
            string path = GetPath();
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                PlayerData = JsonUtility.FromJson<PlayerData>(json);
            }
            else
            {
                PlayerData = new PlayerData();
            }
        }
    }
}