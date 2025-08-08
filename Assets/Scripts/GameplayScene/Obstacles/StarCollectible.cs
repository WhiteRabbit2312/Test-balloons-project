using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    public class StarCollectible : MonoBehaviour, ICollectable
    {
        public void OnCollect()
        {
            Debug.Log("Star collected!");
            // GameManager.Instance.AddStar();
            Destroy(gameObject);
        }
    }
}