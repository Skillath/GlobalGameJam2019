using GGJ2019.Core.Entities;

namespace GGJ2019.Game.Entities
{
    public interface IGameUIAdapter : IWindow
    {
        void ShowLifePoins(int lifePoints);

        void SetCurrentWave(int wave, int maxWave);
    }
}
