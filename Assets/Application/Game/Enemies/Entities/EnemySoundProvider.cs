using GGJ2019.Game.Entities;
using UnityEngine;

namespace GGJ2019.UnityGames.Enemies.Entities
{
    public class EnemySoundProvider : MonoBehaviour, IEnemySoundProvider
    {
        [SerializeField]
        private AudioSource audioSource;

        [SerializeField]
        private AudioClip deathSound;
        [SerializeField]
        private AudioClip idleSound;
        [SerializeField]
        private AudioClip houseReachedSound;

        public void PlayDeathSound() => audioSource.PlayOneShot(deathSound);
        public void PlayHouseReachedSound() => audioSource.PlayOneShot(houseReachedSound);
        public void PlayIdleSound() => audioSource.PlayOneShot(idleSound);
    }
}
