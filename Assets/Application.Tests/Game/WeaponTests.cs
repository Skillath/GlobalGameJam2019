using GGJ2019.Game.Entities;
using GGJ2019.Tests.Common;
using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;

namespace GGJ2019.Tests.Games
{
    public class WeaponTests : CommonIntegrationTest
    {
        [UnityTest]
        [Timeout(30000)]
        public IEnumerator InstantiateWeapons()
        {
            var loader = Container.TryResolve<IWeaponLoader>();
            Assert.That(loader, Is.Not.Null);

            for (int i = 0; i < 10; i++)
            {
                var bean = loader.LoadWeapon(WeaponType.Bean);
                var carrot = loader.LoadWeapon(WeaponType.Carrot);
                var watermelon = loader.LoadWeapon(WeaponType.Watermelon);
                yield return null;
                Assert.That(bean, Is.Not.Null);
                Assert.That(carrot, Is.Not.Null);
                Assert.That(watermelon, Is.Not.Null);
            }
        }
    }
}
