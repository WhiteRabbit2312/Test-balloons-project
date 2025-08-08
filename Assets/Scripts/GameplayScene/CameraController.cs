using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;

        [SerializeField] private float _smoothSpeed = 0.125f;

        private Vector3 _offset;

        private void Start()
        {
            if (_playerTransform != null)
            {
                _offset = transform.position - _playerTransform.position;
            }
        }
        
        private void LateUpdate()
        {
            if (_playerTransform == null)
            {
                return;
            }

            float desiredYPosition = _playerTransform.position.y + _offset.y;
            Vector3 desiredPosition = new Vector3(transform.position.x, desiredYPosition, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}