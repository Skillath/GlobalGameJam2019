using GGJ2019.Core.Entities;

namespace GGJ2019.Game.Adapters
{
    public interface IGameUIAdapter : IWindow
    {
        IPlayerUIAdapter PlayerUIAdapter { get; }

        ICardsUIAdapter CardsUIAdapter { get; }

        void SetCurrentWave(int wave, int maxWave);

        

    }
}
