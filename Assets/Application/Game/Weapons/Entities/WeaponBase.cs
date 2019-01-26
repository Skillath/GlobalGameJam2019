using GGJ2019.Core.Models;
using GGJ2019.Game.Entities;
using UnityEngine;

namespace GGJ2019.UnityGames.Weapons.Entities
{
    public abstract class WeaponBase : MonoBehaviour, IWeapon
    {
        [SerializeField]
        private int hp;
        [SerializeField]
        private int cost;

        public int HP => hp;
        public int Cost => cost;
        public virtual Vector Position => this.transform.position.ToVector();

        public abstract IWeaponEffect Effect { get; }
        public abstract IWeaponAnimator Animator { get; }
        public abstract IWeaponHitDetector HitDetector { get; }
        public abstract IWeaponSoundProvider SoundProvider { get; }

        protected virtual void Init()
        {
            Effect.Init();
            Effect.OnEffectDone += Effect_OnEffectDone;

            HitDetector.IsEnabled = true;
            HitDetector.OnHit += HitDetector_OnHit;
        }

        protected virtual void HitDetector_OnHit(IEnemy enemy) {
            hp -= enemy.Damage;
            if(hp <= 0)
            {
                Stop();
                Debug.Log("DEAD");
                SoundProvider.PlayDeathSound();
                Animator.PlayDeathAnimation();
            }
        }

        protected virtual void Effect_OnEffectDone()
        {
            Animator.PlayEffectAnimation();
            SoundProvider.PlayEffectSound();
        }

        protected virtual void Stop()
        {
            Effect.Stop();
            Effect.OnEffectDone -= Effect_OnEffectDone;

            HitDetector.IsEnabled = false;
            HitDetector.OnHit -= HitDetector_OnHit;
        }


    }
}
