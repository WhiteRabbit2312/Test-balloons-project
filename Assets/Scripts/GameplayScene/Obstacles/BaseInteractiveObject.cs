using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace TestProject
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Collider2D))]
    public abstract class BaseInteractiveObject : MonoBehaviour, IInteractiveObject
    {
        [SerializeField] protected ObstacleAnimation ObstacleAnimation;
        [SerializeField] protected int Score = 10;
        [SerializeField] protected int HP = 1;
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

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.TryGetComponent(out PlayerMovement player))
            {
                ObstacleAnimation.Disappear();
                OnCollideWithPlayer(other.gameObject);
            }
            
            if (other.CompareTag(Constants.DeadZoneTag))
            {
                Destroy(gameObject);
            }
            
            if (other.CompareTag(Constants.PlayAreaTag))
            {
                if (gameObject.layer == LayerMask.NameToLayer(Constants.PreGameObjectsName))
                {
                    gameObject.layer = LayerMask.NameToLayer(Constants.ActiveObjectsName);
                }
            }
        }
    }
}