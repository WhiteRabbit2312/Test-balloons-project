using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace TestProject
{
    public class MyProfileScreen : UIScreen
    {
        [SerializeField] private Button _saveButton;
        [SerializeField] private TMP_InputField _playerNameInputField;
        [SerializeField] private TMP_Text _playerNameText;

        private string _defaultPlayerName = "Name nickname";
        private string _defaultInputField = "Change your name";
        public override void Open()
        {
            base.Open();
            _saveButton.onClick.AddListener(Save);
            _playerNameText.text = PlayerPrefs.GetString(Constants.PlayerNameID, _defaultPlayerName);
            _playerNameInputField.text = _defaultInputField;
            _playerNameInputField.onValueChanged.AddListener(InsertNewName);
        }

        private void InsertNewName(string value)
        {
            
        }

        private void Save()
        {
            _playerNameText.text = _playerNameInputField.text;
            PlayerPrefs.SetString(Constants.PlayerNameID, _playerNameText.text);
        }
    }
}