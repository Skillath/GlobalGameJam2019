using GGJ2019.Game.Entities;
using UnityEngine;

namespace GGJ2019.UnityGames.Entities
{
    public abstract class BaseEnemy : MonoBehaviour, IEnemy
    {
        [SerializeField]
        private int hp;

        [SerializeField]
        private int damage;

        [SerializeField]
        private float speed;

        public int HP => hp;

        public int Damage => damage;

        public float Speed => speed;

        protected virtual void Awake() { }
        protected virtual void Start() { }
        protected virtual void OnDestroy() { }

    }
}