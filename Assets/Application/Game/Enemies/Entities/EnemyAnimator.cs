using GGJ2019.Game.Entities;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace GGJ2019.UnityGames.Enemies.Entities
{
    public class EnemyAnimator : MonoBehaviour, IEnemyAnimator
    {
        [SerializeField]
        private Animator animator;
        [SerializeField]
        private string walkTrigger;

        public Task Die(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public Task HouseReached(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        public void Love()
        {
            animator.SetBool(walkTrigger, false);
        }

        public void Walk()
        {
            animator.SetBool(walkTrigger, true);
        }
    }
}
