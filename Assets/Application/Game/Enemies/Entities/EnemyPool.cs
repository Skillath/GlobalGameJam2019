using GGJ2019.Game.Entities;
using Zenject;

namespace GGJ2019.UnityGames.Enemies.Entities
{
    public class EnemyPool : MonoMemoryPool<BaseEnemy>
    {
        public EnemyType EnemyType { get; private set; }

        [Inject]
        public EnemyPool(EnemyType enemyType)
        {
            EnemyType = enemyType;
        }
    }
}
