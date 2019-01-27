using GGJ2019.Game.Entities;
using UnityEngine;

namespace GGJ2019.UnityGames.Weapons.Entities
{
    public class TankWeapon : WeaponBase
    {
        [SerializeField]
        private WeaponDOTweenAnimator animator;

        [SerializeField]
        private WeaponSoundProvider soundProvider;

        public override IWeaponEffect Effect => new NullWeaponEffect();

        public override IWeaponAnimator Animator => animator;

        public override IWeaponSoundProvider SoundProvider => soundProvider;
    }
}
