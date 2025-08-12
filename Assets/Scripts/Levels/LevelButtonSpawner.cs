using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class LevelButtonSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _levelButtonPrefab;
        [SerializeField] private Transform _buttonContainer;
        
        private List<LevelData> _allLevels;
        private DiContainer _container;
        
        [Inject]
        public void Construct(List<LevelData> allLevels, DiContainer container)
        {
            _allLevels = allLevels;
            _container = container;
        }
        
        private void Start()
        {
            CreateLevelButtons();
        }

        private void CreateLevelButtons()
        {
            foreach (LevelData levelData in _allLevels)
            {
                GameObject buttonGO = _container.InstantiatePrefab(_levelButtonPrefab, _buttonContainer);
                LevelButton button = buttonGO.GetComponent<LevelButton>();
                button.SetLevelData(levelData);
            }
        }
    }
}