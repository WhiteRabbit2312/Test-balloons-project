using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace TestProject
{
    public class MultiTapInteractiveObject : BaseObstacle
    {
        [SerializeField] private int _tapsRequired = 4;
        private int _currentTaps = 0;

        public override void OnTap()
        {
            _currentTaps++;
            Debug.Log($"{gameObject.name} tapped. Taps remaining: {_tapsRequired - _currentTaps}");

            transform.localScale *= 0.9f;

            if (_currentTaps >= _tapsRequired)
            {
                Debug.Log($"{gameObject.name} was destroyed by multiple taps.");
                Destroy(gameObject, Constants.AnimationDuration);
            }
        }
    }
}