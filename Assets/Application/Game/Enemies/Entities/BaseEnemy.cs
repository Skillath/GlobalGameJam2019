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

        [SerializeField]
        private int damage;

        [SerializeField]
        private float speed;

        private TaskCompletionSource<bool> tcs;
        private CancellationToken? cancellationToken = null;
        private bool TaskCompleted => !(tcs != null && (!tcs.Task.IsCompleted && !tcs.Task.IsCanceled && !tcs.Task.IsFaulted));

        public int HP
        {
            get => hp;
            set
            {
                hp = value;
                if (hp < 0)
                {
                    if (TaskCompleted)
                    {
                        tcs.SetResult(false);
                    }
                }
            }
        }

        public int Damage => damage;

        public float Speed => speed;

        public abstract IEnemySoundProvider SoundProvider { get; }
        public abstract IEnemyAnimator Animator { get; }

        public Vector Position => this.transform.position.ToVector();

        public bool CanMove { set; protected get; }

        public bool IsAlive => HP > 0;

        protected virtual void Awake() { }
        protected virtual void Start() { }
        protected virtual void OnDestroy() { }

        public void Init()
        {
            CanMove = true;
            tcs = new TaskCompletionSource<bool>();
        }

        public virtual void Update()
        {
            if (!cancellationToken.HasValue || cancellationToken.Value.IsCancellationRequested)
            {
                Stop();
                return;
            }

            if (CanMove)
            {
                this.transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
            }
        }

        public void Stop()
        {
            if (!TaskCompleted)
            {
                tcs.SetResult(false);
            }
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