using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace TestProject
{
    public class ShopScreen : UIScreen
    {
        [Space]
        [Header("Shop Screen")]
        [SerializeField] private BuyPopUp _buyPopUp;
        [SerializeField] private int _itemsPerPage = 4;
        [SerializeField] private GameObject _panelPrefab;
        [SerializeField] private Transform _panelsContainer;

        [SerializeField] private Button _nextButton;
        [SerializeField] private Button _previousButton;

        [SerializeField] private GameObject _shopButtonPrefab;

        private List<SkinData> _allSkins;
        private ShopManager _shopManager;
        private DiContainer _container;

        private List<GameObject> _instantiatedPanels = new List<GameObject>();
        private List<ShopItemButton> _spawnedButtons = new List<ShopItemButton>();
        private int _currentPageIndex = 0;
        
        [Inject]
        public void Construct(List<SkinData> allSkins, ShopManager shopManager, DiContainer container)
        {
            _allSkins = allSkins;
            _container = container;
            _shopManager = shopManager;
            _shopManager.OnSkinStateChanged += RefreshAllButtonVisuals;
        }
        
        public override void Open()
        {
            base.Open();
            if (_instantiatedPanels.Count == 0) 
            {
                SetupPages();
            }
            ShowPage(0); 

            _nextButton.onClick.AddListener(ShowNextPage);
            _previousButton.onClick.AddListener(ShowPreviousPage);
        }

        public override void Close()
        {
            base.Close();
            _nextButton.onClick.RemoveListener(ShowNextPage);
            _previousButton.onClick.RemoveListener(ShowPreviousPage);
        }
        
        private void SetupPages()
        {
            int totalPages = Mathf.CeilToInt((float)_allSkins.Count / _itemsPerPage);

            for (int i = 0; i < totalPages; i++)
            {
                GameObject panelGO = Instantiate(_panelPrefab, _panelsContainer);
                panelGO.name = $"Page_{i}";
            
                List<SkinData> pageSkins = _allSkins.Skip(i * _itemsPerPage).Take(_itemsPerPage).ToList();

                foreach (var skinData in pageSkins)
                {
                    GameObject buttonGO = _container.InstantiatePrefab(_shopButtonPrefab, panelGO.transform);
                    ShopItemButton button = buttonGO.GetComponent<ShopItemButton>();
                    button.SetSkinData(skinData, _buyPopUp);
                    _spawnedButtons.Add(button);
                }
            
                _instantiatedPanels.Add(panelGO);
                panelGO.SetActive(false); 
            }
        }
        
        private void RefreshAllButtonVisuals()
        {
            foreach (var button in _spawnedButtons)
            {
                button.UpdateVisuals();
            }
        }
        
        private void ShowPage(int index)
        {
            if (index < 0 || index >= _instantiatedPanels.Count)
            {
                return;
            }

            if (_instantiatedPanels.Count > 0)
            {
                _instantiatedPanels[_currentPageIndex].SetActive(false);
            }
        
            _currentPageIndex = index;
            _instantiatedPanels[_currentPageIndex].SetActive(true);

            UpdateNavButtons();
        }
        
        private void ShowNextPage() => ShowPage(_currentPageIndex + 1);
        private void ShowPreviousPage() => ShowPage(_currentPageIndex - 1);

        
        private void UpdateNavButtons()
        {
            _previousButton.interactable = _currentPageIndex > 0;
            _nextButton.interactable = _currentPageIndex < _instantiatedPanels.Count - 1;
        }

        private void DestroyPanels()
        {
            foreach (var panel in _instantiatedPanels)
            {
                Destroy(panel);
            }
            _instantiatedPanels.Clear();
            _spawnedButtons.Clear();
        }

        private void OnDestroy()
        {
            if (_shopManager != null)
            {
                _shopManager.OnSkinStateChanged -= RefreshAllButtonVisuals;
            }
            DestroyPanels();
        }
    }
}