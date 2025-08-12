using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TestProject
{
    [RequireComponent(typeof(Button))]
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private GameObject _lockIcon;
        [SerializeField] private List<GameObject> _starIcons = new List<GameObject>();
        [SerializeField] private TMP_Text _levelNameText;
        
        private Button _button;
        private LevelData _levelData;
        private LevelManager _levelManager;

        [Inject]
        public void Construct(LevelManager levelManager)
        {
            _levelManager = levelManager;
        }
        
        private void Awake()
        {
            _button = GetComponent<Button>();
        }

        public void SetLevelData(LevelData levelData)
        {
            _levelData = levelData;
            SetupVisuals();
        }
        
        private void SetupVisuals()
        {
            bool isUnlocked = _levelManager.IsLevelUnlocked(_levelData);
            
            if (_levelNameText != null && isUnlocked)
            {
                _levelNameText.text = _levelData.LevelID;
            }
            
            _button.interactable = isUnlocked;
            _lockIcon.SetActive(!isUnlocked);
        
            if (isUnlocked)
            {
                int stars = _levelManager.GetStars(_levelData);
                for (int i = 0; i < _starIcons.Count; i++)
                {
                    _starIcons[i].SetActive(i < stars);
                }
            }
            else
            {
                foreach (var star in _starIcons)
                {
                    star.SetActive(false);
                }
            }
        
            _button.onClick.AddListener(OnButtonClick);
        }

        private void OnButtonClick()
        {
            _levelManager.StartLevel(_levelData);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnButtonClick);
        }
    }
}