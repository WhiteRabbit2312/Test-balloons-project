using Zenject;

namespace TestProject
{
    public class UIInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<UIManager>().AsSingle().NonLazy();
        }
    }
}