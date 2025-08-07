using Zenject;

namespace TestProject
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerDataService>().AsSingle().NonLazy();
            Container.Bind<LevelManager>().AsSingle();
            Container.Bind<ShopManager>().AsSingle();
        }
    }
}