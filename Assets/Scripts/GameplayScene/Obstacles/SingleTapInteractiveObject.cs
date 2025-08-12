using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    public class SingleTapInteractiveObject : BaseObstacle
    {
        public override void OnTap()
        {
            ObstacleAnimation.Disappear();
            Destroy(gameObject, Constants.AnimationDuration);
        }
    }
}