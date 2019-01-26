using GGJ2019.Core.Adapters;
using GGJ2019.Core.Entities;
using GGJ2019.Game.Adapters;
using GGJ2019.Utils.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace GGJ2019.Game.Entities
{

    public class GameStrategy
    {
        private readonly WindowNavigation windowNavigation;
        private readonly ITimeAdapter timeAdapter;
        private readonly IGameLoader gameLoader;
        private readonly Player player;
        private readonly IGridAdapter gridAdapter;
        private readonly ILogger logger;

        private IGameUIAdapter gameUIAdapter;
        private Game currentGame;
        private GameResult currentGameResult;

        private IGameType gameType;

        public GameStrategy(WindowNavigation windowNavigation, ITimeAdapter timeAdapter, IGameLoader gameLoader, Player player, IGridAdapter gridAdapter, ILogger logger)
        {
            this.windowNavigation = windowNavigation;
            this.timeAdapter = timeAdapter;
            this.gameLoader = gameLoader;
            this.player = player;
            this.gridAdapter = gridAdapter;
            this.logger = logger;
        }

        public async Task Load(Game game)
        {
            gridAdapter.Init();
            currentGame = game;

            currentGameResult = new GameResult()
            {
                Score = 0,
                Stars = 0,
                WavesAlive = 0,
                WavesResults = new WaveResult[currentGame.Waves.Length],
            };

            for (int i = 0; i < currentGameResult.WavesResults.Length; i++)
            {
                currentGameResult.WavesResults[i] = CreateSkippedResult();
            }

            await gameLoader.LoadGame((int)currentGame.GameType);
        }

        private WaveResult CreateSkippedResult() =>
            new WaveResult()
            {
                Alive = false,
                VegansKilled = -1,
            };

        public async Task<GameResult> PlayGame(CancellationToken cancellationToken)
        {
            //Initial animation
            await gameType.StartAnimation(cancellationToken);
            await windowNavigation.Show<IGameUIAdapter>(cancellationToken);

            for (int i = 0; i < currentGame.Waves.Length && !cancellationToken.IsCancellationRequested; i++)
            {
                var currentWave = currentGame.Waves[i];
                var waveResult = await PlayWave(currentWave, cancellationToken);

                currentGameResult.WavesResults[i] = waveResult;
            }

            if (!cancellationToken.IsCancellationRequested)
            {
                //ShowResults
            }
            await windowNavigation.Hide<IGameUIAdapter>(cancellationToken);
            await gameType.EndAnimation(cancellationToken);

            return currentGameResult;
        }

        private async Task<WaveResult> PlayWave(Wave currentWave, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return CreateSkippedResult();
            }

            logger.Log($"Wave; {currentWave.Vegans}");
            await timeAdapter.Delay(2000, cancellationToken);

            return null;
        }

        public Task Unload()
        {
            currentGame = null;
            currentGameResult = null;

            return Task.CompletedTask;
        }
    }
}