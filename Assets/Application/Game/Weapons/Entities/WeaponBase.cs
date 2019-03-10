using GGJ2019.Game.Entities;
using UnityEngine;
using WorstGameStudios.Core.Abstractions.Engine.Coordinates;
using WorstGameStudios.Core.Utils.ExtensionMethods;

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
                if (hp < 0)
                {
                    hp = 0;
                    SoundProvider.PlayDeathSound();
                    Animator.PlayDeathAnimation();
                    OnWeaponDie?.Invoke();
                }
            }
        }
        public int Cost => cost;
        public virtual Vector Position
        {
            get => this.transform.position.ToVector();
            set => this.transform.position = value.ToVector3();
        }

        public abstract IWeaponEffect Effect { get; }
        public abstract IWeaponAnimator Animator { get; }
        public abstract IWeaponSoundProvider SoundProvider { get; }

        public bool Alive => HP > 0;

        protected virtual void Init()
        {
            Effect.Init();
            Effect.OnEffectDone += Effect_OnEffectDone;
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
        }


    }
}
