using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    [RequireComponent(typeof(Animator))]
    public class ObstacleAnimation : MonoBehaviour
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Disappear()
        {
            Debug.LogError("Disappear");
            _animator.Play("Disappear");
        }
    }
}