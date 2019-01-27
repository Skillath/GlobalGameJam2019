using GGJ2019.Core.Models;
using GGJ2019.Game.Entities;
using UnityEngine;

namespace GGJ2019.UnityGames.Enemies.Entities
{
    public class EnemySimpleMovement : MonoBehaviour, IEnemyMovement
    {
        [SerializeField]
        private Transform target;

        [SerializeField]
        private float speed;

        public Vector Position
        {
            get => target.position.ToVector();
            set => target.position = value.ToVector3();
        }

        public bool CanMove { set; private get; } = false;

        public float Speed => speed;

        private void Update()
        {
            if (CanMove)
            {
                target.Translate(Vector3.forward * speed * 10 * Time.deltaTime, Space.Self);
                target.transform.rotation = Quaternion.Euler(Vector3.up * 180);
            }
        }
    }
}
