using GGJ2019.Game.Entities;
using GGJ2019.UnityGames.Weapons.Entities;
using System.Collections;
using UnityEngine;
using Zenject;

namespace GGJ2019.UnityGames.Enemies.Entities
{
    public class EnemyHitDetector : MonoBehaviour, IEnemyHitDetector
    {
        public event EnemyHitDetectorCollisionHandler<IWeapon> OnWeaponHit = delegate { };
        public event EnemyHitDetectorCollisionHandler<IWeapon> OnWeaponRelease = delegate { };
        public event EnemyHitDetectorCollisionHandler<Player> OnPlayerReached = delegate { };

        [SerializeField]
        private int damage;
        [SerializeField]
        private float damageDelay;

        [SerializeField]
        private new Collider collider;

        private Player player;
        

        public void LoadPlayer(Player player) => this.player = player;

        public int Damage => damage;

        public float DamageDelay => DamageDelay;

        public bool IsEnabled
        {
            get => collider.enabled;
            set => collider.enabled = value;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Weapon"))
            {
                var weapon = other.GetComponentInParent<WeaponBase>();
                OnWeaponHit?.Invoke(weapon);
                StartCoroutine(DoDamage(weapon));
            }
            else if (other.CompareTag("Player"))
            {
                player.HP -= Damage;
                OnPlayerReached?.Invoke(player);
            }

        }

        private IEnumerator DoDamage(IWeapon weapon)
        {
            while (IsEnabled && weapon.Alive)
            {
                yield return new WaitForSeconds(DamageDelay);
                weapon.HP -= Damage;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Weapon"))
            {
                var weapon = other.GetComponentInParent<WeaponBase>();
                OnWeaponHit?.Invoke(weapon);
                StopCoroutine(DoDamage(weapon));
            }
            else if (other.CompareTag("Player"))
            {

            }
        }

        
    }
}
