using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGJ2019.Game.Entities
{
    public delegate void WeaponHitDetectorEventHandler(IEnemy enemy);
    public interface IWeaponHitDetector
    {
        event WeaponHitDetectorEventHandler OnHit;

        bool IsEnabled { get; set; }
    }
}
