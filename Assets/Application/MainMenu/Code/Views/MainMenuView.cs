using GGJ2019.MainMenu.Views;
using GGJ2019.UnityCore.Entities;
using UnityEngine;
using UnityEngine.UI;

namespace GGJ2019.UnityMainMenu.Views
{
    public class MainMenuView : View, IMainMenuView
    {
        public event MainMenuEventHandleAdapter OnPlay = delegate { };

        [SerializeField]
        private Button btnPlay;

        protected override void Start()
        {
            base.Start();

            btnPlay?.onClick.RemoveAllListeners();
            btnPlay?.onClick.AddListener(() => OnPlay?.Invoke());
        }
    }
}
