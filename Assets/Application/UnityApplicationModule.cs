using Assets.Application.Game.Code.Adapters;
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
using GGJ2019.UnityGames.Enemies.Entities;
using GGJ2019.UnityGames.Entities;
using GGJ2019.UnityGames.Weapons.Entities;
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
    [SerializeField]
    private ResultsUIAdapter resultsUI;

    [Header("Enemy")]
    [SerializeField]
    private RedEnemy redEnemy;
    [SerializeField]
    private GreenEnemy greenEnemy;
    [SerializeField]
    private BlueEnemy blueEnemy;

    [Header("Weapon")]
    [SerializeField]
    private EnergyWeapon energyWeapon;
    [SerializeField]
    private TankWeapon tankWeapon;
    [SerializeField]
    private ShootingWeapon shootingWeapon;

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
        Container.Bind(typeof(IWindow), typeof(IResultsUIAdapter)).To<ResultsUIAdapter>().FromComponentInNewPrefab(resultsUI).AsSingle();

        Container.Bind<IApplicationQuitter>().To<ApplicationQuitter>().FromNew().AsSingle();
        Container.Bind<IPauseAdapter>().To<PauseAdapter>().FromNewComponentOnNewGameObject().AsSingle();

        Container.Bind<IGameLoader>().To<GameLoader>().AsSingle();
        Container.Bind<IGridAdapter>().To<GridAdapter>().FromNewComponentOnNewGameObject().AsSingle();
        Container.Bind<IPlayerMPGenerator>().To<PlayerMPGenerator>().FromNewComponentOnNewGameObject().AsSingle().WithArguments(2, 5, 2);

        var enemyPool = Container.CreateEmptyGameObject("EnemyPool");
        Container.BindMemoryPool<RedEnemy, EnemyPool>()
            .WithInitialSize(5)
            .ExpandByOneAtATime()
            .WithFactoryArguments(EnemyType.VeganRed)
            .FromComponentInNewPrefab(redEnemy)
            .UnderTransformGroup(enemyPool.name)
            .AsCached();
        Container.BindMemoryPool<GreenEnemy, EnemyPool>()
            .WithInitialSize(5)
            .ExpandByOneAtATime()
            .WithFactoryArguments(EnemyType.VeganGreen)
            .FromComponentInNewPrefab(greenEnemy)
            .UnderTransformGroup(enemyPool.name)
            .AsCached();
        Container.BindMemoryPool<BlueEnemy, EnemyPool>()
            .WithInitialSize(5)
            .ExpandByOneAtATime()
            .WithFactoryArguments(EnemyType.VeganBlue)
            .FromComponentInNewPrefab(blueEnemy)
            .UnderTransformGroup(enemyPool.name)
            .AsCached();

        var weaponsPool = Container.CreateEmptyGameObject("WeaponsPool");
        Container.BindMemoryPool<ShootingWeapon, WeaponPool>()
            .WithInitialSize(5)
            .ExpandByOneAtATime()
            .WithFactoryArguments(WeaponType.Bean)
            .FromComponentInNewPrefab(shootingWeapon)
            .UnderTransformGroup(weaponsPool.name)
            .AsCached();
        Container.BindMemoryPool<TankWeapon, WeaponPool>()
            .WithInitialSize(5)
            .ExpandByOneAtATime()
            .WithFactoryArguments(WeaponType.Carrot)
            .FromComponentInNewPrefab(tankWeapon)
            .UnderTransformGroup(weaponsPool.name)
            .AsCached();
        Container.BindMemoryPool<EnergyWeapon, WeaponPool>()
            .WithInitialSize(5)
            .ExpandByOneAtATime()
            .WithFactoryArguments(WeaponType.Watermelon)
            .FromComponentInNewPrefab(energyWeapon)
            .UnderTransformGroup(weaponsPool.name)
            .AsCached();

        Container.Bind<IEnemyLoader>().To<EnemyLoader>().AsSingle();
        Container.Bind<IWeaponLoader>().To<WeaponLoader>().AsSingle();

    }
}
