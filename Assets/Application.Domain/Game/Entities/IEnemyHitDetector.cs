using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GGJ2019.Game.Entities
{
    public delegate void EnemyHitDetectorCollisionHandler<T>(T collision);

    public interface IEnemyHitDetector
    {
        event EnemyHitDetectorCollisionHandler<IWeapon> OnWeaponReached;
        event EnemyHitDetectorCollisionHandler<Player> OnPlayerReached;

        int Damage { get; }
    }
}
