using GGJ2019.Game.Entities;
using System;
using UnityEngine;

namespace GGJ2019.UnityGames.Weapons.Entities
{
    public class WeaponSoundProvider : MonoBehaviour, IWeaponSoundProvider
    {
        [SerializeField]
        private AudioSource audioSource;

        [SerializeField]
        private AudioClip spawn;
        [SerializeField]
        private AudioClip death;
        [SerializeField]
        private AudioClip effect;

        public void PlayDeathSound() => audioSource.PlayOneShot(death);

        public void PlayEffectSound() => audioSource.PlayOneShot(effect);

        public void PlaySpawnSound() => audioSource.PlayOneShot(spawn);
    }
}
