using UnityEngine;
using UnityEngine.UI;

namespace TestProject
{
    public class SettingsSlider : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Button _decreaseSoundButton;
        [SerializeField] private Button _increaseSoundButton;

        [Space] [SerializeField] private string _settingKey;
        [SerializeField] private int _defaultValue;

        private int _soundVolume;

        private void Awake()
        {
            _decreaseSoundButton.onClick.AddListener(Decrease);
            _increaseSoundButton.onClick.AddListener(Increase);

            InitSlider();
        }

        private void InitSlider()
        {
            _slider.value = PlayerPrefs.GetFloat(_settingKey, _defaultValue);
        }

        private void Increase()
        {
            if (_soundVolume < _slider.maxValue)
            {
                _soundVolume++;
                _slider.value = _soundVolume;
                SaveSettings();
            }
        }

        private void Decrease()
        {
            if (_soundVolume > 0)
            {
                _soundVolume--;
                _slider.value = _soundVolume;
                SaveSettings();
            }
        }

        private void SaveSettings()
        {
            PlayerPrefs.SetInt(_settingKey, _soundVolume);
        }
    }
}