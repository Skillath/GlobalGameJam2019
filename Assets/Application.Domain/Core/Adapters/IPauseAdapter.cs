using GGJ2019.Core.Entities;

namespace GGJ2019.Core.Adapters
{
    public delegate void PauseAdapterEventHandler();
    public interface IPauseAdapter : IWindow
    {
        event PauseAdapterEventHandler OnPause;

        bool IsPaused { get; }

        void Pause();
        void Resume();
    }
}
