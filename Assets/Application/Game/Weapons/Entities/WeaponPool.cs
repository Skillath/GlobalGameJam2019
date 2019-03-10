using GGJ2019.Game.Entities;
using Zenject;

namespace GGJ2019.UnityGames.Weapons.Entities
{
    public class WeaponPool : MonoMemoryPool<WeaponBase>
    {
        public WeaponType WeaponType { get; private set; }

        [Inject]
        public WeaponPool(WeaponType weaponType)
        {
            WeaponType = weaponType;
        }

    }
}
