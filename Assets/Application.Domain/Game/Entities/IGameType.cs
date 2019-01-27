using GGJ2019.Game.Adapters;
using System.Threading;
using System.Threading.Tasks;

namespace GGJ2019.Game.Entities
{
    public interface IGameType
    {
        IGridAdapter GridAdapter { get; }

        void SetupCamera();

        void UnlockCamera();
        Task StartAnimation(CancellationToken cancellationToken);
        Task EndAnimation(CancellationToken cancellationToken);
    }
}
