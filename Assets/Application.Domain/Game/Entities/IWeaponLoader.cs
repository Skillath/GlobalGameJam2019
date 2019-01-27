using GGJ2019.Game.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGJ2019.Game.Entities
{
    public interface IWeaponLoader
    {
        

        IWeapon LoadWeapon(WeaponType type);

        void RemoveWeapon(WeaponType type, IWeapon weapon);
    }
}
