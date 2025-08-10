using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 5f;

        private void Update()
        {
            transform.Translate(Vector3.up * _moveSpeed * Time.deltaTime);
        }
    }
}