using GGJ2019.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace GGJ2019.Game.Entities
{
    public interface IEnemy
    {
        int HP { get; set; }

        bool IsAlive { get; }

        int Damage { get; }

        float Speed { get; }

        bool CanMove { set; }

        Vector Position { get; }

        IEnemyAnimator Animator { get; }

        IEnemySoundProvider SoundProvider { get; }

        void Init();

        void Stop();

        Task WaitForCompletion(CancellationToken cancellationToken);
    }
}