using GGJ2019.Core.Entities;

namespace GGJ2019.MainMenu.Views
{
    public delegate void MainMenuEventHandleAdapter();

    public interface IMainMenuView : IWindow
    {
        event MainMenuEventHandleAdapter OnPlay;
    }
}