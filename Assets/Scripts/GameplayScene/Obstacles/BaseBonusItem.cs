using UnityEngine;

namespace TestProject
{
    public class BaseBonusItem : BaseInteractiveObject
    {
        public override void OnCollideWithPlayer(GameObject player)
        {
            player.GetComponent<PlayerScore>().Increase(Score);
            player.GetComponent<PlayerStatus>().IncreaseHealth(HP);
            Destroy(gameObject, Constants.AnimationDuration);
        }
    }
}