using NUnit.Framework;
using WorstGameStudios.Core.Abstractions.Engine.Logger;
using WorstGameStudios.Core.Abstractions.Engine.Time;
using Zenject;

namespace GGJ2019.Tests.Common
{
    [TestFixture]
    public abstract class CommonIntegrationTest : ZenjectIntegrationTestFixture, ITest
    {
        protected ILogger logger;
        protected ITimeAdapter timeAdapter;

        [SetUp]
        public void SetupContainer()
        {
            PreInstall();

            PostInstall();

            Construct();
        }


        public virtual void Construct()
        {
            logger = Container.TryResolve<ILogger>();
            Assert.That(logger, Is.Not.Null);

            timeAdapter = Container.TryResolve<ITimeAdapter>();
            Assert.That(timeAdapter, Is.Not.Null);
        }
    }
}
