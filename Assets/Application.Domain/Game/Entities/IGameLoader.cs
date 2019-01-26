using GGJ2019.Game.Entities;
using System.Threading.Tasks;
using Zenject;

namespace GGJ2019.Game.Entities
{
    public interface IGameLoader
    {
        Task<IGameType> LoadGame(int buildIndex);

        Task Unload();
    }
}
