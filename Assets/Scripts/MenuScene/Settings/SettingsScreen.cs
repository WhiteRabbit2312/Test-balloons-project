using UnityEngine;
using UnityEngine.UI;
namespace TestProject
{
    public class SettingsScreen : UIScreen
    {
        [Header("Sound Settings")]
        [SerializeField] private Slider _soundVolumeSlider;
        [SerializeField] private string _settingSoundKey;

        [Space] 
        [Header("Sound Settings")]
        [SerializeField] private Slider _musicVolumeSlider;
        [SerializeField] private string _settingMusicKey;

        [Space]
        [SerializeField] private int _defaultValue;
        [SerializeField] private Button _saveButton;

        private float _soundVolume;
        private float _musicVolume;

        private void Start()
        {
            _saveButton.onClick.AddListener(SaveSettings);
        }

        public override void Open()
        {
            base.Open();
            InitSound();
            InitMusic();
        }
        
        private void InitSound()
        {
            _soundVolumeSlider.value = PlayerPrefs.GetFloat(_settingSoundKey, _defaultValue);
            _soundVolume = _soundVolumeSlider.value;
        }
        
        private void InitMusic()
        {
            _musicVolumeSlider.value = PlayerPrefs.GetFloat(_settingMusicKey, _defaultValue);
            _musicVolume = _musicVolumeSlider.value;
        }

        public void IncreaseVolume(int id)
        {
            GameSettings settings = (GameSettings)id;
            if (settings == GameSettings.Music)
            {
                if (_musicVolume < _musicVolumeSlider.maxValue)
                {
                    _musicVolume++;
                    UpdateSettings(_musicVolumeSlider, _musicVolume);
                }
            }
            else if (settings == GameSettings.Sound)
            {
                if (_soundVolume < _soundVolumeSlider.maxValue)
                {
                    _soundVolume++;
                    UpdateSettings(_soundVolumeSlider, _soundVolume);
                }
            }
        }
        
        public void DecreaseVolume(int id)
        {
            GameSettings settings = (GameSettings)id;
            if (settings == GameSettings.Music)
            {
                if (_musicVolume > 0)
                {
                    _musicVolume--;
                    UpdateSettings(_musicVolumeSlider, _musicVolume);
                }

            }
            else if (settings == GameSettings.Sound)
            {
                if (_soundVolume > 0)
                {
                    _soundVolume--;
                    UpdateSettings(_soundVolumeSlider, _soundVolume);
                }
            }
        }

        private void UpdateSettings(Slider slider, float value)
        {
            slider.value = value;
        }
        
        private void SaveSettings()
        {
            PlayerPrefs.SetFloat(_settingSoundKey, _soundVolume);
            PlayerPrefs.SetFloat(_settingMusicKey, _musicVolume);
        }
    }

    public enum GameSettings
    {
        Music = 0,
        Sound = 1
    }
}