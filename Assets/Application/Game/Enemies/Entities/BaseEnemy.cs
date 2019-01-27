using GGJ2019.Core.Models;
using GGJ2019.Game.Entities;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace GGJ2019.UnityGames.Enemies.Entities
{
    public abstract class BaseEnemy : MonoBehaviour, IEnemy
    {
        [SerializeField]
        private int hp;

        private TaskCompletionSource<bool> tcs;
        private CancellationToken? cancellationToken = null;

        private bool TaskCompleted => tcs?.Task.IsCompleted ?? true;
        public EnemyState EnemyState { get; }
        public abstract IEnemyMovement Movement { get; }
        public abstract IEnemyHitDetector HitDetector { get; }
        public abstract IEnemySoundProvider SoundProvider { get; }
        public abstract IEnemyAnimator Animator { get; }


        protected virtual void Awake() { }
        protected virtual void Start() { }
        protected virtual void OnDestroy() { }

        public void Init()
        {
            HitDetector.OnPlayerReached += HitDetector_OnPlayerReached;
            HitDetector.OnWeaponReached += HitDetector_OnWeaponReached;
            EnemyState.OnEnemyDie += EnemyState_OnEnemyDie;

            this.EnemyState.HP = hp;

            Movement.CanMove = true;
            tcs = new TaskCompletionSource<bool>();
        }

        private void EnemyState_OnEnemyDie()
        {
            if(!TaskCompleted)
            {
                tcs?.SetResult(true);
            }
        }

        private void HitDetector_OnWeaponReached(IWeapon collision)
        {
            if(!EnemyState.IsAlive)
            {
                return; 
            }

            void onWeaponDie()
            {
                collision.OnWeaponDie -= onWeaponDie;
                Movement.CanMove = true;
            }

            collision.OnWeaponDie += onWeaponDie;
            Movement.CanMove = false;

        }

        private void HitDetector_OnPlayerReached(Player collision)
        {
            Movement.CanMove = false;
            if(!TaskCompleted)
            {
                tcs?.SetResult(false);
            }
        }

        public void Stop()
        {
            HitDetector.OnPlayerReached -= HitDetector_OnPlayerReached;
            HitDetector.OnWeaponReached -= HitDetector_OnWeaponReached;
            EnemyState.OnEnemyDie -= EnemyState_OnEnemyDie;
        }

        public async Task WaitForCompletion(CancellationToken cancellationToken)
        {
            this.cancellationToken = cancellationToken;
            bool enemyDead = await tcs.Task;
            this.cancellationToken = null;
            tcs = null;

            if (cancellationToken.IsCancellationRequested)
            {
                return;
            }

            if (enemyDead)
            {
                SoundProvider.PlayDeathSound();
            }
            else
            {
                SoundProvider.PlayHouseReachedSound();
            }

            var animationTask = enemyDead ? Animator.Die(cancellationToken) : Animator.HouseReached(cancellationToken);
            await animationTask;
        }
    }
}