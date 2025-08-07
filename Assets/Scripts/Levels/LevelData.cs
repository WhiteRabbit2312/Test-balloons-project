using UnityEngine;

namespace TestProject
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Game/Level Data")]
    public class LevelData : ScriptableObject
    {
        [field: SerializeField] public string LevelID { get; private set; }
        [field: SerializeField] public GameObject LevelPrefab { get; private set; }
        [field: SerializeField] public LevelData PrerequisiteLevel { get; private set; }
    }
}