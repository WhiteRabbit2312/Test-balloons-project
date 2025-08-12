using UnityEngine;

namespace TestProject
{
    public class ThrowableBonusItem : BaseBonusItem
    {
        [SerializeField] private float _swipeForceMultiplier = 1.0f;
        public override void OnSwipe(Vector2 swipeForce)
        {
            Rb.AddForce(swipeForce * _swipeForceMultiplier, ForceMode2D.Impulse);
        }
    }
}