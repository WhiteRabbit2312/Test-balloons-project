using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace TestProject
{
    public class ThrowableInteractiveObject : BaseObstacle
    {
        [SerializeField] private float _swipeForceMultiplier = 1.0f;

        public override void OnSwipe(Vector2 swipeForce)
        {
            Rb.AddForce(swipeForce * _swipeForceMultiplier, ForceMode2D.Impulse);
            Debug.Log($"Swiped {gameObject.name} with force {swipeForce * _swipeForceMultiplier}");
        }
    }
}