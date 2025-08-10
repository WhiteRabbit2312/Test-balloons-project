using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    public class CollectableContainer
    {
        public int StarQuantity { get; private set; }

        public void CollectStar()
        {
            StarQuantity++;
        }
    }
}