using GGJ2019.Core.DataProvider;
using GGJ2019.Tests.Common;
using NUnit.Framework;
using System.Collections;
using UnityEngine.TestTools;

using TestGame = GGJ2019.Game.Entities.Game;

namespace GGJ2019.Tests.Core
{
    public class DataProviderTests : CommonIntegrationTest
    {
        [UnityTest]
        public IEnumerator LoadGameFromStreamingAssetsTests()
        {
            var dataProvider = Container.TryResolve<IDataProvider<TestGame>>();
            Assert.That(dataProvider, Is.Not.Null);

            var loadTask = dataProvider.GetData();
            yield return loadTask.AsIEnumerator();
            Assert.That(loadTask.IsCompleted && !loadTask.IsCanceled && !loadTask.IsFaulted);

            var game = loadTask.Result;
            Assert.That(game, Is.Not.Null);
        }
    }
}
