using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class BaseCollectableItem : MonoBehaviour, ICollectable
    {
        [Inject] protected CollectableContainer CollectableContainer;
        public virtual void OnCollect()
        {
            
        }
        
        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(Constants.DeadZoneTag))
            {
                Destroy(gameObject);
            }
            
            if (other.CompareTag(Constants.PlayAreaTag))
            {
                if (gameObject.layer == LayerMask.NameToLayer(Constants.PreGameObjectsName))
                {
                    gameObject.layer = LayerMask.NameToLayer(Constants.ActiveCollectableName);
                }
            }
        }
    }
}