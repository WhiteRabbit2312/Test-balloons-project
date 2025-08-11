using UnityEngine;
using UnityEngine.UI;
namespace TestProject
{
    public class SettingsScreen : UIScreen
    {
        [SerializeField] private Button _decreaseSoundButton;
        [SerializeField] private Button _increaseSoundButton;
        [SerializeField] private Button _saveButton;

        [Space] 
        [SerializeField] private string _settingKey;
        [SerializeField] private int _defaultValue;
    }
}