using GGJ2019.Game.Entities;
using UnityEngine;

namespace GGJ2019.UnityGames.Weapons.Entities
{
    public class WeaponSimpleHitDetector : MonoBehaviour, IWeaponHitDetector
    {
        public event WeaponHitDetectorEventHandler OnHit = delegate { };

        [SerializeField]
        private BoxCollider collider;

        public bool IsEnabled
        {
            get => collider.enabled;
            set => collider.enabled = value;
        }

        private void OnTriggerEnter(Collider other)
        {

        }
    }
}
