using System.Threading;
using System.Threading.Tasks;

namespace GGJ2019.Game.Entities
{
    public interface IEnemyAnimator
    {
        void Walk();

        void Love();

        Task Die(CancellationToken cancellationToken);
        Task HouseReached(CancellationToken cancellationToken);
    }
}
