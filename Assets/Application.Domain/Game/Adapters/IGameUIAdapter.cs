using GGJ2019.Core.Entities;

namespace GGJ2019.Game.Adapters
{
    public interface IGameUIAdapter : IWindow
    {
        IPlayerUIAdapter PlayerUIAdapter { get; }

        void ShowLifePoins(int lifePoints);

        void SetCurrentWave(int wave, int maxWave);

    }
}
