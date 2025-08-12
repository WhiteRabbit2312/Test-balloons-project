using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class LeaderboardScreen : UIScreen
    {
        [SerializeField] private Transform _leaderboardContainer;
        [SerializeField] private LeaderboardPlayer _playerInLeaderboardPrefab;
        
        [SerializeField] private int _fakePlayerCount = 3; 
        [SerializeField] private List<string> _playerNames = new List<string> { "ShadowStriker", "CyberNinja", "Vortex", "Phoenix", "Quantum", "Rogue", "Blaze", "Serpent" };
        [SerializeField] private Vector2Int _scoreRange = new Vector2Int(100, 5000); 


        [SerializeField] private Sprite _defaultSprite; 
        [SerializeField] private Color _realPlayerHighlightColor = Color.yellow; 
        
        [SerializeField] private LeaderboardPlayer _topPlayerDisplay; 

        private PlayerDataService _playerDataService;
        private List<LeaderboardPlayer> _spawnedEntries = new List<LeaderboardPlayer>();
        [Inject]
        public void Construct(PlayerDataService playerDataService)
        {
            _playerDataService = playerDataService;
        }
        
        private struct LeaderboardEntryData
        {
            public string Name;
            public int Score;
            public bool IsRealPlayer;
        }

        
         public override void Open()
        {
            base.Open();
            GenerateAndDisplayLeaderboard();
        }

        public override void Close()
        {
            base.Close();
            ClearLeaderboard();
        }

        private void GenerateAndDisplayLeaderboard()
        {
            ClearLeaderboard();

            var leaderboardEntries = new List<LeaderboardEntryData>();

            for (int i = 0; i < _fakePlayerCount; i++)
            {
                leaderboardEntries.Add(new LeaderboardEntryData
                {
                    Name = _playerNames[Random.Range(0, _playerNames.Count)],
                    Score = Random.Range(_scoreRange.x, _scoreRange.y),
                    IsRealPlayer = false
                });
            }

            leaderboardEntries.Add(new LeaderboardEntryData
            {
                Name = "You",
                Score = _playerDataService.PlayerData.Score,
                IsRealPlayer = true
            });

            var sortedEntries = leaderboardEntries.OrderByDescending(entry => entry.Score).ToList();

            if (sortedEntries.Count == 0) return;

            var topPlayer = sortedEntries[0];
            Sprite topPlayerSprite = topPlayer.IsRealPlayer ? GetRealPlayerSprite() : _defaultSprite;
            _topPlayerDisplay.Init(1, topPlayer.Name, topPlayer.Score, topPlayerSprite);
            if (topPlayer.IsRealPlayer)
            {
                _topPlayerDisplay.Highlight(_realPlayerHighlightColor);
            }
            _topPlayerDisplay.gameObject.SetActive(true);


            for (int i = 1; i < sortedEntries.Count; i++)
            {
                LeaderboardPlayer playerEntry = Instantiate(_playerInLeaderboardPrefab, _leaderboardContainer);
                var data = sortedEntries[i];

                //тут нужно подгрузить эту аватарку игрока
                Sprite playerSprite = data.IsRealPlayer ? GetRealPlayerSprite() : _defaultSprite;
                playerEntry.Init(i + 1, data.Name, data.Score, playerSprite);

                if (data.IsRealPlayer)
                {
                    playerEntry.Highlight(_realPlayerHighlightColor);
                }
                _spawnedEntries.Add(playerEntry);
            }
        }

        private Sprite GetRealPlayerSprite()
        {
            //тут нужно подгрузить эту аватарку игрока
            return _defaultSprite;
        }

        private void ClearLeaderboard()
        {
            foreach (var entry in _spawnedEntries)
            {
                Destroy(entry.gameObject);
            }
            _spawnedEntries.Clear();
        }
    }
}
