using GGJ2019.Core.Models;

namespace GGJ2019.Game.Entities
{
    public delegate void WeaponLifeEventHandler();
    public delegate void WeaponHPEventHandler(int hp);
    public interface IWeapon
    {
        int HP { get; }

        Vector Position { get; }

        IWeaponEffect Effect { get; }

        IWeaponAnimator Animator { get; }

        IWeaponHitDetector HitDetector { get; }
    }
}
