using GGJ2019.Core.Adapters;
using GGJ2019.Game.Entities;
using GGJ2019.MainMenu.Views;
using GGJ2019.Utils.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace GGJ2019.Core.Entities
{

    public class App
    {
        private readonly IApplicationQuitter applicationQuitter;
        private readonly IRoot root;
        private readonly IPauseAdapter pauseAdapter;
        private readonly ILogger logger;
        private readonly WindowNavigation windowNavigation;
        private readonly GameStrategyFactory gameStrategyFactory;

        private CancellationTokenSource gameCancellationTokenSource;
        private CancellationTokenSource uiCancellationTokenSource;

        public App(IApplicationQuitter applicationQuitter, WindowNavigation windowNavigation, IRoot root, IPauseAdapter pauseAdapter, ILogger logger, GameStrategyFactory gameFactory)
        {
            this.applicationQuitter = applicationQuitter;
            this.windowNavigation = windowNavigation;
            this.root = root;
            this.pauseAdapter = pauseAdapter;
            this.logger = logger;
            this.gameStrategyFactory = gameFactory;

            applicationQuitter.OnQuit += ApplicationQuitter_OnQuit;
            pauseAdapter.OnPause += PauseAdapter_OnPause;
            root.OnInitialized += Root_OnInitialized;
        }

        private void Root_OnInitialized()
        {
            root.OnInitialized -= Root_OnInitialized;

            var mainMenuAdapter = root.Resolve<IMainMenuView>();

            mainMenuAdapter.OnPlay += MainMenuAdapter_OnPlay;

            _ = windowNavigation.Show(mainMenuAdapter, CancellationToken.None);

        }

        private async void MainMenuAdapter_OnPlay()
        {
            gameCancellationTokenSource = new CancellationTokenSource();
            _ = windowNavigation.Hide<IMainMenuView>(CancellationToken.None);
            var game = gameStrategyFactory.Create();

            await game.Load(new Game.Entities.Game());

            GameResult result = null;

            try
            {
                result = await game.PlayGame(gameCancellationTokenSource.Token);
            }
            catch (TaskCanceledException) { }

            await game.Unload();

            game = null;
            gameCancellationTokenSource = null;
        }

        private void PauseAdapter_OnPause()
        {
            logger.Log("PauseAdapter_OnPause");
        }

        private Task ApplicationQuitter_OnQuit()
        {
            pauseAdapter.OnPause -= PauseAdapter_OnPause;
            applicationQuitter.OnQuit -= ApplicationQuitter_OnQuit;

            gameCancellationTokenSource?.Cancel();
            gameCancellationTokenSource = null;
            uiCancellationTokenSource?.Cancel();
            uiCancellationTokenSource = null;

            return Task.CompletedTask;
        }
    }
}
