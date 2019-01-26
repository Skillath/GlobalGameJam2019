using GGJ2019.Game.Entities;
using System;
using UnityEngine;

namespace GGJ2019.UnityGames.Enemies.Entities
{
    public class RedEnemy : BaseEnemy
    {
        [SerializeField]
        private EnemyAnimator animator;

        [SerializeField]
        private EnemySoundProvider soundProvider;

        public override IEnemySoundProvider SoundProvider => soundProvider;

        public override IEnemyAnimator Animator => animator;
    }
}
