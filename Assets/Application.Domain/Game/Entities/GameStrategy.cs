using GGJ2019.Game.Adapters;
using System.Threading;
using System.Threading.Tasks;
using WorstGameStudios.Core.Abstractions.Engine.UI;

namespace GGJ2019.Game.Entities
{

    public class GameStrategy
    {
        private readonly WindowNavigation windowNavigation;
        private readonly IGameLoader gameLoader;
        private readonly WaveStrategy waveStrategy;
        private readonly IResultsUIAdapter resultsUIAdapter;

        private IGameUIAdapter gameUIAdapter;
        private Game currentGame;
        private GameResult currentGameResult;

        private IGameType gameType;

        public GameStrategy(WindowNavigation windowNavigation, IGameLoader gameLoader, WaveStrategy waveStrategy, IResultsUIAdapter resultsUIAdapter)
        {
            this.windowNavigation = windowNavigation;
            this.gameLoader = gameLoader;
            this.waveStrategy = waveStrategy;
            this.resultsUIAdapter = resultsUIAdapter;
        }

        public async Task Load(Game game)
        {
            currentGame = game;
            gameType = await gameLoader.LoadGame((int)currentGame.GameType);
            gameType.GridAdapter.Init(game.Width, game.Height);
            gameType.SetupCamera();


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
            gameUIAdapter = (IGameUIAdapter)(await windowNavigation.Show<IGameUIAdapter>(cancellationToken));
            _ = gameUIAdapter.CardsUIAdapter.Hide(cancellationToken);


            for (int i = 0; i < currentGame.Waves.Length && !cancellationToken.IsCancellationRequested; i++)
            {
                gameUIAdapter.SetCurrentWave(i, currentGame.Waves.Length);
                gameUIAdapter.PlayerUIAdapter.Load();

                var currentWave = currentGame.Waves[i];
                var waveResult = await waveStrategy.PlayWave(gameType, currentWave, cancellationToken);

                gameUIAdapter.PlayerUIAdapter.Unload();

                currentGameResult.WavesResults[i] = waveResult;
            }

            if (!cancellationToken.IsCancellationRequested)
            {
                resultsUIAdapter.LoadResult(currentGameResult);
                await resultsUIAdapter.Show(cancellationToken);
            }

            await windowNavigation.Hide<IGameUIAdapter>(cancellationToken);
            await gameType.EndAnimation(cancellationToken);

            return currentGameResult;
        }

        public async Task Unload()
        {
            gameType.UnlockCamera();
            currentGame = null;
            currentGameResult = null;
            gameType = null;

            await gameLoader.Unload();
        }
    }
}