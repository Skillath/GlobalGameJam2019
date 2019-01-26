using GGJ2019.Core.Adapters;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GGJ2019.Game.Entities
{

    public class GameStrategy
    {
        private readonly ITimeAdapter timeAdapter;

        private Game currentGame;
        private GameResult currentGameResult;

        public GameStrategy(ITimeAdapter timeAdapter)
        {
            this.timeAdapter = timeAdapter;
        }

        public Task Load(Game game)
        {
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

            return Task.CompletedTask;
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

            return currentGameResult;
        }

        private async Task<WaveResult> PlayWave(Wave currentWave, CancellationToken cancellationToken)
        {
            if (!cancellationToken.IsCancellationRequested)
            {
                return CreateSkippedResult();
            }

            await timeAdapter.Delay(TimeSpan.FromSeconds(currentWave.Vegans), cancellationToken);

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