using NUnit.Framework;
using System.Collections;
using UnityEngine.TestTools;
using Zenject;

namespace GGJ.Tests.Common
{
    [TestFixture]
    public abstract class CommonIntegrationTest : ZenjectIntegrationTestFixture, ITest
    {
        //protected ILogger logger;
        //protected ITimeAdapter timeAdapter;

        [SetUp]
        public void SetupContainer()
        {
            PreInstall();

            PostInstall();

            Construct();
        }


        public virtual void Construct()
        {
            /*logger = Container.TryResolve<ILogger>();
            Assert.That(logger, Is.Not.Null);

            timeAdapter = Container.TryResolve<ITimeAdapter>();
            Assert.That(timeAdapter, Is.Not.Null);*/
        }
    }
}
