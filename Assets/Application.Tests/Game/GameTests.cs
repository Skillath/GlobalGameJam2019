using GGJ2019.Game.Entities;
using GGJ2019.Tests.Common;
using NUnit.Framework;
using System.Collections;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.TestTools;

using GameData = GGJ2019.Game.Entities.Game;

namespace GGJ2019.Tests.Games
{
    public class GameTests : CommonIntegrationTest
    {
        private IGameLoader gameLoader;

        public override void Construct()
        {
            base.Construct();

            gameLoader = Container.TryResolve<IGameLoader>();
            Assert.That(gameLoader, Is.Not.Null);
        }

        [UnityTest]
        public IEnumerator LoadSceneTest()
        {
            var loadTask = gameLoader.LoadGame(1);
            yield return loadTask.AsIEnumerator();
            Assert.That(loadTask.IsCompleted && !loadTask.IsCanceled && !loadTask.IsFaulted);
            var gameType = loadTask.Result;
            Assert.That(gameType, Is.Not.Null);

            yield return new WaitForSeconds(10);
        }

        [UnityTest]
        public IEnumerator PlayGameTest()
        {
            var task = PlayTest(GetGame(3), CancellationToken.None);
            yield return task.AsIEnumerator();
            Assert.That(task.IsCompleted && !task.IsCanceled);
        }

        private GameData GetGame(int waves)
        {
            var game = new GameData()
            {
                GameType = GameType.Default,
                Waves = new Wave[waves],
            };

            for (int i = 0; i < waves; i++)
            {
                game.Waves[i] = new Wave()
                {
                    //Enemies = i,
                };

            }

            return game;
        }

        private async Task<GameResult> PlayTest(GameData game, CancellationToken cancellationToken)
        {
            var gameFactory = Container.TryResolve<GameStrategyFactory>();
            Assert.That(gameFactory, Is.Not.Null);

            var gameStrategy = gameFactory.Create();

            await gameStrategy.Load(game);
            var result = await gameStrategy.PlayGame(cancellationToken);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.WavesResults.Length == game.Waves.Length);

            await gameStrategy.Unload();
            gameStrategy = null;

            return result;
        }
    }
}
