using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TestProject
{
    public class ChoosePhotoPopUp : UIPopup
    {
        [Header("Choose Photo Screen")]
        [SerializeField] private Button _additionalCloseButton;

        protected override void Awake()
        {
            base.Awake();
            if (_additionalCloseButton != null)
            {
                _additionalCloseButton.onClick.AddListener(() => UiManager.ClosePopup(this));
            }
        }
    }
}