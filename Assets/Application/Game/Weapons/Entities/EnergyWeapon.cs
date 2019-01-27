using GGJ2019.Game.Entities;
using UnityEngine;

namespace GGJ2019.UnityGames.Weapons.Entities
{
    public class EnergyWeapon : WeaponBase
    {
        [SerializeField]
        private EnergyWeaponEffect weaponEffect;

        [SerializeField]
        private WeaponDOTweenAnimator animator;

        [SerializeField]
        private WeaponSimpleHitDetector hitDetector;

        [SerializeField]
        private WeaponSoundProvider soundProvider;

        public override IWeaponEffect Effect => weaponEffect;

        public override IWeaponAnimator Animator => animator;

        public override IWeaponHitDetector HitDetector => hitDetector;

        public override IWeaponSoundProvider SoundProvider => soundProvider;
    }
}
