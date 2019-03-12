using System.Threading;
using System.Threading.Tasks;
using WorstGameStudios.Core.Abstractions.Engine.Time;

namespace GGJ2019.Game.Entities
{
    public class EnemySpawner
    {
        private readonly Player player;
        private readonly IEnemyLoader enemyLoader;
        private readonly ITimeAdapter timeAdapter;

        public EnemySpawner(Player player, IEnemyLoader enemyLoader, ITimeAdapter timeAdapter)
        {
            this.player = player;
            this.enemyLoader = enemyLoader;
            this.timeAdapter = timeAdapter;
        }

        public IEnemy[] Enemies { get; private set; }

        public async Task LoadEnemies(Wave wave, CancellationToken cancellationToken)
        {
            Enemies = new IEnemy[wave.Enemies.Length];
            for (int i = 0; i < wave.Enemies.Length && !cancellationToken.IsCancellationRequested && player.Alive; i++)
            {
                await timeAdapter.Delay(1000, cancellationToken);
                var enemy = enemyLoader.LoadEnemy(wave.Enemies[i].Type);
                Enemies[i] = enemy;

                _ = enemy.WaitForCompletion(cancellationToken);


            }
        }
    }
}
