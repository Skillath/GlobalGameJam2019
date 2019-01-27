using GGJ2019.Core.Models;
using GGJ2019.Game.Entities;
using System;
using UnityEngine;

namespace GGJ2019.UnityGames.Enemies.Entities
{
    public class EnemySimpleMovement : MonoBehaviour, IEnemyMovement
    {
        [SerializeField]
        private Transform target;

        [SerializeField]
        private float speed;

        public Vector Position => target.position.ToVector();

        public bool CanMove { set; private get; } = false;

        public float Speed => speed;

        private void Update()
        {
            if(CanMove)
            {
                target.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
            }
        }
    }
}
