using GGJ2019.Game.Entities;
using UnityEngine;

namespace GGJ2019.UnityGames.Weapons.Entities
{
    public class ShootingWeapon : WeaponBase
    {
        [SerializeField]
        private ShootingWeaponEffect effect;

        [SerializeField]
        private WeaponDOTweenAnimator animator;

        [SerializeField]
        private WeaponSimpleHitDetector hitDetector;

        [SerializeField]
        private WeaponSoundProvider soundProvider;

        public override IWeaponEffect Effect => effect;

        public override IWeaponAnimator Animator => animator;

        public override IWeaponHitDetector HitDetector => hitDetector;

        public override IWeaponSoundProvider SoundProvider => soundProvider;


    }
}
