using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    public class StarCollectible : MonoBehaviour, ICollectable
    {
        [Inject] private CollectableContainer _collectableContainer;
        
        public void OnCollect()
        {
            Debug.Log("Star collected!");
            _collectableContainer.CollectStar();
            Destroy(gameObject);
        }
    }
}