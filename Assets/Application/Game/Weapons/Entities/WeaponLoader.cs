using GGJ2019.Game.Entities;
using System.Collections.Generic;

namespace GGJ2019.UnityGames.Weapons.Entities
{
    public class WeaponLoader : IWeaponLoader
    {
        private Dictionary<WeaponType, WeaponPool> loaders = new Dictionary<WeaponType, WeaponPool>();



        public WeaponLoader(IList<WeaponPool> pools)
        {
            loaders.Clear();
            foreach (var pool in pools)
            {
                loaders.Add(pool.WeaponType, pool);
            }
        }

        public IWeapon LoadWeapon(WeaponType type)
        {
            return loaders[type].Spawn();
        }

        public void RemoveWeapon(WeaponType type, IWeapon weapon)
        {
            loaders[type].Despawn((WeaponBase)weapon);
        }
    }
}
