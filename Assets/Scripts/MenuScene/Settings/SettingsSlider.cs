using UnityEngine;
using UnityEngine.UI;

namespace TestProject
{
    [RequireComponent(typeof(Slider))]
    public class SettingsSlider : MonoBehaviour
    {
        [SerializeField] private Button _decreaseSoundButton;
        [SerializeField] private Button _increaseSoundButton;
        [SerializeField] private Button _saveButton;

        [Space] 
        [SerializeField] private string _settingKey;
        [SerializeField] private int _defaultValue;

        private Slider _slider;
        private int _soundVolume;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _decreaseSoundButton.onClick.AddListener(Decrease);
            _increaseSoundButton.onClick.AddListener(Increase);
            _saveButton.onClick.AddListener(SaveSettings);

            InitSlider();
        }

        private void InitSlider()
        {
            _slider.value = PlayerPrefs.GetFloat(_settingKey, _defaultValue);
            _soundVolume = PlayerPrefs.GetInt(_settingKey, _defaultValue);
        }

        private void Increase()
        {
            if (_soundVolume < _slider.maxValue)
            {
                _soundVolume++;
                _slider.value = _soundVolume;
            }
        }

        private void Decrease()
        {
            if (_soundVolume > 0)
            {
                _soundVolume--;
                _slider.value = _soundVolume;
            }
        }

        private void SaveSettings()
        {
            PlayerPrefs.SetInt(_settingKey, _soundVolume);
        }
    }
}