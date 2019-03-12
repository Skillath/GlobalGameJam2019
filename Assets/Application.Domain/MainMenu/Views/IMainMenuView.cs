using WorstGameStudios.Core.Abstractions.Engine.UI;

namespace GGJ2019.MainMenu.Views
{
    public delegate void MainMenuEventHandleAdapter();

    public interface IMainMenuView : IWindow
    {
        event MainMenuEventHandleAdapter OnPlay;
    }
}