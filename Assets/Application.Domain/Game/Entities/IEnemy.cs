using GGJ2019.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace GGJ2019.Game.Entities
{
    public interface IEnemy
    {
        EnemyState EnemyState { get; }

        IEnemyMovement Movement { get; }

        IEnemyAnimator Animator { get; }

        IEnemySoundProvider SoundProvider { get; }

        IEnemyHitDetector HitDetector { get; }

        void Init();

        void Stop();

        Task WaitForCompletion(CancellationToken cancellationToken);
    }
}