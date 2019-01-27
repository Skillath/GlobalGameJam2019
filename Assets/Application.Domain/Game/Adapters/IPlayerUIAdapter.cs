using GGJ2019.Core.Entities;
using GGJ2019.Game.Entities;

namespace GGJ2019.Game.Adapters
{
    public interface IPlayerUIAdapter : IWindow
    {
        void Load(Player player);

        void Unload();
    }
}
