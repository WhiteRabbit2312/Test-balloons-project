using UnityEngine;

namespace TestProject
{
    public class MultiTapInteractiveObject : BaseObstacle
    {
        [SerializeField] private int _tapsRequired = 4;
        private int _currentTaps = 0;

        public override void OnTap()
        {
            _currentTaps++;
            transform.localScale *= 0.9f;

            if (_currentTaps >= _tapsRequired)
            {
                ObstacleAnimation.Disappear();
                Destroy(gameObject, Constants.AnimationDuration);
            }
        }
    }
}