using GGJ2019.Game.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GGJ2019.UnityGames.Enemies.Entities
{
    public class EnemyHitDetector : MonoBehaviour, IEnemyHitDetector
    {
        public event EnemyHitDetectorCollisionHandler<IWeapon> OnWeaponReached = delegate { };
        public event EnemyHitDetectorCollisionHandler<Player> OnPlayerReached = delegate { };

        [SerializeField]
        private int damage;

        [SerializeField]
        private Collider collider;

        public int Damage => damage;

        private void OnTriggerEnter(Collider other)
        {
            
        }

    }
}
