using GGJ2019.Core.Models;
using GGJ2019.Game.Entities;
using UnityEngine;

namespace GGJ2019.UnityGames.Weapons.Entities
{
    public abstract class WeaponBase : MonoBehaviour, IWeapon
    {
        public event WeaponEffectEventHandler OnWeaponDie = delegate { };
        public event WeaponHPEventHandler OnWeaponHPChange = delegate { };

        [SerializeField]
        private int hp;
        [SerializeField]
        private int cost;

        public int HP
        {
            get => hp;
            set
            {
                hp = value;
                OnWeaponHPChange?.Invoke(hp < 0 ? 0 : hp);
                if(hp < 0)
                {
                    hp = 0;
                    OnWeaponDie?.Invoke();
                }
            }
        }
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

        protected virtual void HitDetector_OnHit(IEnemy enemy)
        {
            hp -= enemy.HitDetector.Damage;
            if (hp <= 0)
            {
                Stop();
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
