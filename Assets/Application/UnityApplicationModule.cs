using GGJ.Core.Adapters;
using GGJ.Core.Entities;
using GGJ.Core.Services;
using GGJ.MainMenu.Views;
using GGJ.UnityCore.Adapters;
using GGJ.UnityCore.Entities;
using GGJ.UnityCore.Services;
using GGJ.UnityMainMenu.Views;
using UnityEngine;
using Zenject;

using ILogger = GGJ.Utils.Entities.ILogger;
using Logger = GGJ.UnityUtils.Entities.Logger;

[CreateAssetMenu(fileName = "UnityApplicationModule", menuName = "Installers/UnityApplicationModule")]
public class UnityApplicationModule : ScriptableObjectInstaller<UnityApplicationModule>
{
    [SerializeField]
    private Root root;
    [SerializeField]
    private MainMenuView mainMenu;

    public override void InstallBindings()
    {
        ApplicationModule.Install(Container);

        Container.Bind<IRoot>().To<Root>().FromComponentInNewPrefab(root).AsSingle();

        Container.Bind<ITimeAdapter>().To<TimeAdapter>().FromNewComponentOnNewGameObject().AsSingle();
        Container.Bind<ITimeService>().To<TimeService>().AsSingle();
        Container.Bind<ILogger>().To<Logger>().AsSingle();

        Container.Bind(typeof(IWindow), typeof(IMainMenuView)).To<MainMenuView>().FromComponentInNewPrefab(mainMenu).AsSingle();


        Container.Bind<IApplicationQuitter>().To<ApplicationQuitter>().FromNew().AsSingle();
        Container.Bind<IPauseAdapter>().To<PauseAdapter>().FromNewComponentOnNewGameObject().AsSingle();
    }
}
