using GGJ.Core.Entities;

namespace GGJ.Core.Adapters
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
