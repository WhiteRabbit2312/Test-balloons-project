using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public abstract class BaseInteractiveObject : MonoBehaviour, IInteractiveObject
    {
        [SerializeField] protected int ScorePenalty = 10;
        protected Rigidbody2D Rb;
        
        protected virtual void Awake()
        {
            Rb = GetComponent<Rigidbody2D>();
        }
        
        public virtual void OnSwipe(Vector2 swipeForce)
        {
            
        }

        public virtual void OnTap()
        {
            
        }

        public abstract void OnCollideWithPlayer(GameObject player);

        protected virtual void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                OnCollideWithPlayer(collision.gameObject);
            }
        }
    }
}