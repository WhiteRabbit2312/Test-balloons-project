using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    public class SingleTapInteractiveObject : BaseObstacle
    {
        [SerializeField] private Animator _animator;
        public override void OnTap()
        {
            _animator.Play("Disappear");
            Destroy(gameObject, Constants.AnimationDuration);
        }
    }
}