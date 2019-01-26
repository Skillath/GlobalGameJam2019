using GGJ2019.Core.DataProvider;
using GGJ2019.Core.Entities;
using GGJ2019.Game.Entities;
using Zenject;

public class ApplicationModule : Installer<ApplicationModule>
{
    public override void InstallBindings()
    {
        Container.Bind<IDataProvider<Game>>().To<StreamingAssetsDataProvider<Game>>().FromNew().AsSingle().WithArguments("game.json");

        Container.Bind<WindowNavigation>().FromNew().AsSingle();
        Container.Bind<GameStrategy>().AsSingle();

        Container.BindFactory<GameStrategy, GameStrategyFactory>().AsSingle();
        Container.Bind<Player>().AsSingle().WithArguments(10);
        Container.Bind<Grid>().AsSingle().WithArguments(5, 3);

        Container.Bind<App>().AsSingle();
    }
}