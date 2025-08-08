using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    public class ThrowableInteractiveObject : BaseObstacle
    {
        [SerializeField]
        private float swipeForceMultiplier = 1.0f;

        public override void OnSwipe(Vector2 swipeForce)
        {
            Rb.AddForce(swipeForce * swipeForceMultiplier, ForceMode2D.Impulse);
            Debug.Log($"Swiped {gameObject.name} with force {swipeForce * swipeForceMultiplier}");
        }
    }
}