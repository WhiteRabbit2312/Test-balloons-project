using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestProject
{
    [CreateAssetMenu(fileName = "Skin", menuName = "Game/Skin Data")]
    public class SkinData : ScriptableObject
    {
        public string SkinID;
        public Sprite SkinSprite;
        public int Price;
    }
}