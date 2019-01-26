using System.Threading;
using System.Threading.Tasks;

namespace GGJ2019.Game.Entities
{
    public interface IGameType
    {
        Task StartAnimation(CancellationToken cancellationToken);
        Task EndAnimation(CancellationToken cancellationToken);
    }
}
