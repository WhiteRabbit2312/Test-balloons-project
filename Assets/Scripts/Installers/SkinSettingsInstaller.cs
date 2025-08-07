using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TestProject
{
    [CreateAssetMenu(fileName = "SkinSettingsInstaller", menuName = "Installers/Skin Settings Installer")]
    public class SkinSettingsInstaller : ScriptableObjectInstaller<SkinSettingsInstaller>
    {
        [SerializeField] private List<SkinData> _allSkins;

        public override void InstallBindings()
        {
            Container.Bind<List<SkinData>>().FromInstance(_allSkins).AsSingle();
        }
    }
}