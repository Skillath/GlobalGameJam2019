using GGJ.MainMenu.Views;
using GGJ.UnityCore.Entities;
using UnityEngine;
using UnityEngine.UI;

namespace GGJ.UnityMainMenu.Views
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
