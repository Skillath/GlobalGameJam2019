using GGJ2019.Core.Models;

namespace GGJ2019.Game.Entities
{
    public delegate void WeaponLifeEventHandler();
    public delegate void WeaponHPEventHandler(int hp);
    public interface IWeapon
    {
        event WeaponEffectEventHandler OnWeaponDie;
        event WeaponHPEventHandler OnWeaponHPChange;

        int HP { get; set; }

        int Cost { get; }

        bool Alive { get; }

        Vector Position { get; }

        IWeaponEffect Effect { get; }

        IWeaponAnimator Animator { get; }

        IWeaponHitDetector HitDetector { get; }

        IWeaponSoundProvider SoundProvider { get; }
    }
}
