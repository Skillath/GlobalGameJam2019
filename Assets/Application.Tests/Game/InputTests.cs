using GGJ2019.Game.Entities;
using GGJ2019.Game.Services;
using GGJ2019.Tests.Common;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using WorstGameStudios.Core.Abstractions.Engine.Coordinates;
using WorstGameStudios.Core.Abstractions.Engine.UI;

namespace GGJ2019.Tests.Games
{
    public class InputTests : CommonIntegrationTest
    {
        [UnityTest]
        [Timeout(300000)]
        public IEnumerator TouchGridTest()
        {
            var root = Container.TryResolve<IRoot>();
            Assert.That(root, Is.Not.Null);

            var gameLoader = Container.TryResolve<IGameLoader>();
            Assert.That(gameLoader, Is.Not.Null);

            var loadTask = gameLoader.LoadGame(1);
            yield return loadTask.AsIEnumerator();
            Assert.That(loadTask.IsCompleted && !loadTask.IsCanceled && !loadTask.IsFaulted);
            var gameType = loadTask.Result;
            Assert.That(gameType, Is.Not.Null);

            gameType.SetupCamera();

            var inputService = Container.TryResolve<IInputService>();
            gameType.GridAdapter.Init(10, 10);
            inputService.Setup();
            bool stop = false;

            void onTouch(Vector v)
            {
                var coordinates = gameType.GridAdapter.WorldPositionToGridCoordinates(v);
                Debug.Log($"Coords: {coordinates.gridCoords} {coordinates.cell.Position}");

            }

            void OnPause() => stop = true;


            inputService.OnTouch += onTouch;
            inputService.OnPauseRequested += OnPause;

            yield return new WaitUntil(() => stop);


            inputService.OnPauseRequested -= OnPause;
            inputService.OnTouch -= onTouch;
        }
    }
}
