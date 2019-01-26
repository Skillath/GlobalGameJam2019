using GGJ.Core.Entities;

namespace GGJ.MainMenu.Views
{
    public delegate void MainMenuEventHandleAdapter();

    public interface IMainMenuView : IWindow
    {
        event MainMenuEventHandleAdapter OnPlay;
    }
}