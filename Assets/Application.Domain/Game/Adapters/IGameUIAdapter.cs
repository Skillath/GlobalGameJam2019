using WorstGameStudios.Core.Abstractions.Engine.UI;

namespace GGJ2019.Game.Adapters
{
    public interface IGameUIAdapter : IWindow
    {
        IPlayerUIAdapter PlayerUIAdapter { get; }

        ICardsUIAdapter CardsUIAdapter { get; }

        void SetCurrentWave(int wave, int maxWave);



    }
}
