using GGJ2019.Core.Models;
using GGJ2019.Game.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
