using GGJ2019.Core.Adapters;
using GGJ2019.Core.Entities;
using GGJ2019.Core.Services;
using GGJ2019.Game.Adapters;
using GGJ2019.Game.Entities;
using GGJ2019.MainMenu.Views;
using GGJ2019.UnityCore.Adapters;
using GGJ2019.UnityCore.Entities;
using GGJ2019.UnityCore.Services;
using GGJ2019.UnityGames.Adapters;
using GGJ2019.UnityGames.Entities;
using GGJ2019.UnityMainMenu.Views;
using UnityEngine;
using Zenject;

using ILogger = GGJ2019.Utils.Entities.ILogger;
using Logger = GGJ2019.UnityUtils.Entities.Logger;

[CreateAssetMenu(fileName = "UnityApplicationModule", menuName = "Installers/UnityApplicationModule")]
public class UnityApplicationModule : ScriptableObjectInstaller<UnityApplicationModule>
{
    [SerializeField]
    private Root root;
    [SerializeField]
    private MainMenuView mainMenu;
    [SerializeField]
    private GameUIAdapter gameUI;


    public override void InstallBindings()
    {
        ApplicationModule.Install(Container);

        Container.Bind<IRoot>().To<Root>().FromComponentInNewPrefab(root).AsSingle();

        Container.Bind<ITimeAdapter>().To<TimeAdapter>().FromNewComponentOnNewGameObject().AsSingle();
        Container.Bind<ITimeService>().To<TimeService>().AsSingle();
        Container.Bind<ILogger>().To<Logger>().AsSingle();

        Container.Bind<ILoader>().To<Loader>().FromNew().AsSingle();

        Container.Bind(typeof(IWindow), typeof(IMainMenuView)).To<MainMenuView>().FromComponentInNewPrefab(mainMenu).AsSingle();
        Container.Bind(typeof(IWindow), typeof(IGameUIAdapter)).To<GameUIAdapter>().FromComponentInNewPrefab(gameUI).AsSingle();

        Container.Bind<IApplicationQuitter>().To<ApplicationQuitter>().FromNew().AsSingle();
        Container.Bind<IPauseAdapter>().To<PauseAdapter>().FromNewComponentOnNewGameObject().AsSingle();

        Container.Bind<IGameLoader>().To<GameLoader>().AsSingle();
        Container.Bind<IGridAdapter>().To<GridAdapter>().FromNewComponentOnNewGameObject().AsSingle();

    }
}
