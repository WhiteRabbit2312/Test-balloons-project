using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class PlayerAppearanceController : MonoBehaviour
    {
        private ShopManager _shopManager;
        private SpriteRenderer _spriteRenderer;

        [Inject]
        public void Construct(ShopManager shopManager)
        {
            _shopManager = shopManager;
        }

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            ApplySelectedSkin();
        }

        private void ApplySelectedSkin()
        {
            SkinData selectedSkin = _shopManager.GetSelectedSkinData();

            if (selectedSkin != null && selectedSkin.SkinSprite != null)
            {
                _spriteRenderer.sprite = selectedSkin.SkinSprite;
            }
        }
    }
}