using WorstGameStudios.Core.Abstractions.Engine.Coordinates;

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

        Vector Position { get; set; }

        IWeaponEffect Effect { get; }

        IWeaponAnimator Animator { get; }

        IWeaponSoundProvider SoundProvider { get; }
    }
}
