using GGJ.Core.Adapters;
using GGJ.MainMenu.Views;
using GGJ.Utils.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace GGJ.Core.Entities
{

    public class App
    {
        private readonly IApplicationQuitter applicationQuitter;
        private readonly WindowNavigation windowNavigation;
        private readonly IRoot root;
        private readonly IPauseAdapter pauseAdapter;
        private readonly ILogger logger;
        private CancellationTokenSource gameCancellationTokenSource;
        private CancellationTokenSource uiCancellationTokenSource;

        public App(IApplicationQuitter applicationQuitter, WindowNavigation windowNavigation, IRoot root, IPauseAdapter pauseAdapter, ILogger logger)
        {
            this.applicationQuitter = applicationQuitter;
            this.windowNavigation = windowNavigation;
            this.root = root;
            this.pauseAdapter = pauseAdapter;
            this.logger = logger;
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

        private void MainMenuAdapter_OnPlay()
        {
            gameCancellationTokenSource = new CancellationTokenSource();

            _ = windowNavigation.Hide<IMainMenuView>(CancellationToken.None);



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
