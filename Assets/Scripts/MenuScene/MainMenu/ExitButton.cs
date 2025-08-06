using UnityEngine;
using UnityEngine.UI;

namespace TestProject
{
    [RequireComponent(typeof(Button))]
    public class ExitButton : MonoBehaviour
    {
        private Button _button;
        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(ExitGame);
        }

        private void ExitGame()
        {
            Debug.Log("ExitGame");
            Application.Quit();
        }
    }
}