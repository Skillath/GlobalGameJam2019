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
        event EnemyHitDetectorCollisionHandler<IWeapon> OnWeaponHit;
        event EnemyHitDetectorCollisionHandler<Player> OnPlayerReached;

        void LoadPlayer(Player player);

        bool IsEnabled { get; set; }

        float DamageDelay { get; }

        int Damage { get; }
    }
}
