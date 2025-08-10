using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    [CreateAssetMenu(fileName = "NewPanelConfig", menuName = "Panel/Panel Configuration")]
    public class PanelConfig : ScriptableObject
    {
        public Sprite Title;
        public bool CalculateReward;
    }
}