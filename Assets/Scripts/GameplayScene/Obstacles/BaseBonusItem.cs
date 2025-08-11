using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    public class BaseBonusItem : BaseInteractiveObject
    {
        public override void OnCollideWithPlayer(GameObject player)
        {
            Debug.Log($"Player collected bonus {gameObject.name}. Gained {Score} points.");
            player.GetComponent<PlayerScore>().Increase(Score);
            player.GetComponent<PlayerStatus>().IncreaseHealth(HP);
            Destroy(gameObject, Constants.AnimationDuration);
        }
    }
}