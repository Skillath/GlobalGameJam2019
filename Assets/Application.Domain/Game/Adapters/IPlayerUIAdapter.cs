using WorstGameStudios.Core.Abstractions.Engine.UI;

namespace GGJ2019.Game.Adapters
{
    public interface IPlayerUIAdapter : IWindow
    {
        void Load();

        void Unload();
    }
}
