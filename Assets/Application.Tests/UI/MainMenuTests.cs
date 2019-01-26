using GGJ2019.Core.Entities;
using GGJ2019.MainMenu.Views;
using GGJ2019.Tests.Common;
using GGJ2019.UnityCore.Entities;
using NUnit.Framework;
using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.TestTools;

namespace GGJ2019.Tests.UI
{
    public class MainMenuTests : CommonIntegrationTest
    {
        private IRoot root;
        private WindowNavigation windowNavigation;

        public override void Construct()
        {
            base.Construct();

            root = Container.TryResolve<IRoot>();
            Assert.That(root, Is.Not.Null);

            windowNavigation = Container.TryResolve<WindowNavigation>();
            Assert.That(windowNavigation, Is.Not.Null);
        }

        [UnityTest]
        public IEnumerator ShowAndHideMainMenu()
        {
            var mainMenu = root.Resolve<IMainMenuView>();
            Assert.That(mainMenu, Is.Not.Null);

            var view = (View)mainMenu;

            var showTask = windowNavigation.Show(mainMenu, CancellationToken.None);
            yield return showTask.AsIEnumerator();
            Assert.That(showTask.IsCompleted && !showTask.IsCanceled);
            Assert.That(view.CanvasGroup.alpha >= 1f);

            yield return new WaitForSeconds(3);

            var hideTask = windowNavigation.Hide(mainMenu, CancellationToken.None);
            yield return hideTask.AsIEnumerator();
            Assert.That(hideTask.IsCompleted && !hideTask.IsCanceled);
            Assert.That(view.CanvasGroup.alpha <= 0f);
        }

        [UnityTest]
        public IEnumerator PlayButtonTest()
        {
            var mainMenu = root.Resolve<IMainMenuView>();
            Assert.That(mainMenu, Is.Not.Null);

            bool playHit = false;
            void onPlay()
            {
                mainMenu.OnPlay -= onPlay;
                playHit = true;
            }

            mainMenu.OnPlay += onPlay;

            _ = windowNavigation.Show(mainMenu, CancellationToken.None);

            yield return new WaitUntil(() => playHit);

            Assert.That(playHit);

            var hideTask = windowNavigation.Hide(mainMenu, CancellationToken.None);
            yield return hideTask.AsIEnumerator();
            Assert.That(hideTask.IsCompleted && !hideTask.IsCanceled);
        }
    }
}