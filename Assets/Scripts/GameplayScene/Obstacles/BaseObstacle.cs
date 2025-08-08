using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    public class BaseObstacle : BaseInteractiveObject
    {
        public override void OnCollideWithPlayer(GameObject player)
        {
            Debug.Log($"Player collided with obstacle {gameObject.name}. Lost {ScorePenalty} points.");
            // player.GetComponent<PlayerScore>().Decrease(ScorePenalty);
            Destroy(gameObject);
        }
    }
}