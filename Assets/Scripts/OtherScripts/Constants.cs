using UnityEngine;

namespace TestProject
{
    public class Constants : MonoBehaviour
    {
        public const string GameplaySceneName = "GameplayScene";
        public const string LevelSceneName = "LevelScene";

        public const string DefaultSkinID = "default_skin";
        public const string PlayerNameID = "PlayerName";
        public const string PlayAreaTag = "PlayArea";
        public const string DeadZoneTag = "DeadZone";
        public const string FinishTag = "Finish";
        
        public const string PreGameObjectsName = "PreGameObjects";
        public const string ActiveObjectsName = "ActiveObjects";
        public const string ActiveCollectableName = "ActiveCollectables";
        public const float AnimationDuration = 0.5f;
    }
}