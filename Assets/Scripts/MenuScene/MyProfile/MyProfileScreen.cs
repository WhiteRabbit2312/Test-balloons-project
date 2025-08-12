using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Zenject;

namespace TestProject
{
    public class MyProfileScreen : UIScreen
    {
        [SerializeField] private Button _saveButton;
        [SerializeField] private TMP_InputField _playerNameInputField;
        [SerializeField] private TMP_Text _playerNameText;
        [SerializeField] private Avatar _avatar;

        private AvatarStorage _avatarStorage;
        
        [Inject]
        public void Construct(AvatarStorage avatarStorage)
        {
            _avatarStorage = avatarStorage;
        }
        private string _defaultPlayerName = "Name nickname";
        private string _defaultInputField = "Change your name";
        public override void Open()
        {
            base.Open();
            _saveButton.onClick.RemoveAllListeners();
            _saveButton.onClick.AddListener(Save);
            _playerNameText.text = PlayerPrefs.GetString(Constants.PlayerNameID, _defaultPlayerName);
            _playerNameInputField.text = "";
            _playerNameInputField.placeholder.GetComponent<TMP_Text>().text = _defaultInputField;
            
            if (_avatar != null)
            {
                _avatar.LoadAndDisplaySavedAvatar();
            }
        }

        private void Save()
        {
            if (!string.IsNullOrWhiteSpace(_playerNameInputField.text))
            {
                _playerNameText.text = _playerNameInputField.text;
                PlayerPrefs.SetString(Constants.PlayerNameID, _playerNameText.text);
            }

            if (_avatar != null && _avatar.NewAvatarTexture != null)
            {
                _avatarStorage.SaveAvatar(_avatar.NewAvatarTexture);
                _avatar.ClearNewAvatar();
            }
        }

        private void OnDestroy()
        {
            _saveButton.onClick.RemoveListener(Save);
        }
    }
}