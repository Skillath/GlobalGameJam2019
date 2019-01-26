using GGJ.Core.Adapters;
using GGJ.Utils.Entities;
using NUnit.Framework;
using Zenject;

namespace GGJ.Tests.Common
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
