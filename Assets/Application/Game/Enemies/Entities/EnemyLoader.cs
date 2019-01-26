using GGJ2019.Game.Entities;
using System.Collections.Generic;

namespace GGJ2019.UnityGames.Enemies.Entities
{
    public class EnemyLoader : IEnemyLoader
    {
        private Dictionary<EnemyType, EnemyPool> loaders = new Dictionary<EnemyType, EnemyPool>();

        public EnemyLoader(IList<EnemyPool> pools)
        {
            loaders.Clear();
            foreach (var pool in pools)
            {
                loaders.Add(pool.EnemyType, pool);
            }
        }

        public IEnemy LoadEnemy(EnemyType type)
        {
            var enemyBase = loaders[type].Spawn();
            return enemyBase;
        }

        public void RemoveEnemy(EnemyType type, IEnemy enemy)
        {
            loaders[type].Despawn((BaseEnemy)enemy);
        }
    }
}
