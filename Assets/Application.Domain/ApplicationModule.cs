using GGJ.Core.Entities;
using Zenject;

public class ApplicationModule : Installer<ApplicationModule>
{
    public override void InstallBindings()
    {
        Container.Bind<WindowNavigation>().FromNew().AsSingle();


        Container.Bind<App>().AsSingle().NonLazy();
    }
}