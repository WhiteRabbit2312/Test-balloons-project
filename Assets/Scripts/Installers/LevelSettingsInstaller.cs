using Zenject;
using UnityEngine;
using System.Collections.Generic;

namespace TestProject
{
    [CreateAssetMenu(fileName = "LevelSettingsInstaller", menuName = "Installers/Level Settings Installer")]
    public class LevelSettingsInstaller : ScriptableObjectInstaller<LevelSettingsInstaller>
    {
        [SerializeField] private List<LevelData> _allLevels = new List<LevelData>();

        public override void InstallBindings()
        {
            Container.Bind<List<LevelData>>().FromInstance(_allLevels).AsSingle();
        }
    }
}