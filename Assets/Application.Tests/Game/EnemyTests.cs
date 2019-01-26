using GGJ2019.Game.Entities;
using GGJ2019.Tests.Common;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace GGJ2019.Tests.Games
{
    public class EnemyTests : CommonIntegrationTest
    {
        [UnityTest]
        [Timeout(30000)]
        public IEnumerator InstantiateEnemies()
        {
            var loader = Container.TryResolve<IEnemyLoader>();
            Assert.That(loader, Is.Not.Null);

            for (int i = 0; i < 10; i++)
            {
                var enemyRed = loader.LoadEnemy(EnemyType.VeganRed);
                var enemyGreen = loader.LoadEnemy(EnemyType.VeganGreen);
                var enemyBlue = loader.LoadEnemy(EnemyType.VeganBlue);
                yield return null;
                Assert.That(enemyRed, Is.Not.Null);
                Assert.That(enemyGreen, Is.Not.Null);
                Assert.That(enemyBlue, Is.Not.Null);
            }

            yield return new WaitForSeconds(20);
        }
    }
}
