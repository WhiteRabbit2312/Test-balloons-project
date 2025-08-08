using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    public class SingleTapInteractiveObject : BaseObstacle
    {
        public override void OnTap()
        {
            Debug.Log($"{gameObject.name} was destroyed by a tap.");
            Destroy(gameObject);
        }
    }
}