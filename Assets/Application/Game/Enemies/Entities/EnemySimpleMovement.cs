using GGJ2019.Game.Entities;
using UnityEngine;
using WorstGameStudios.Core.Abstractions.Engine.Coordinates;
using WorstGameStudios.Core.Utils.ExtensionMethods;

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
                target.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
                target.transform.rotation = Quaternion.Euler(Vector3.up * 180);
            }
        }
    }
}
