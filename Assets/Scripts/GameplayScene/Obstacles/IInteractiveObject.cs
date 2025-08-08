using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    public interface IInteractiveObject 
    {
        void OnSwipe(Vector2 swipeForce);
        void OnTap();
        void OnCollideWithPlayer(GameObject player);
    }
}