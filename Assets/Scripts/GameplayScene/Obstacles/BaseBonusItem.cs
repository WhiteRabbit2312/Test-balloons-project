using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    public class BaseBonusItem : BaseInteractiveObject
    {
        [SerializeField]
        protected int ScoreBonus = 20;

        public override void OnCollideWithPlayer(GameObject player)
        {
            Debug.Log($"Player collected bonus {gameObject.name}. Gained {ScoreBonus} points.");
            // player.GetComponent<PlayerScore>().Increase(ScoreBonus);
            Destroy(gameObject);
        }
    }
}