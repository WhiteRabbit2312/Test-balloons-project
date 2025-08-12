using UnityEngine;

namespace TestProject
{
    public class BaseObstacle : BaseInteractiveObject
    {
        public override void OnCollideWithPlayer(GameObject player)
        {
            player.GetComponent<PlayerScore>().Decrease(Score);
            player.GetComponent<PlayerStatus>().DecreaseHealth(HP);
            Destroy(gameObject, Constants.AnimationDuration);
        }
    }
}