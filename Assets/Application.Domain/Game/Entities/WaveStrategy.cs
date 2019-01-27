using GGJ2019.Core.Adapters;
using System.Threading;
using System.Threading.Tasks;

namespace GGJ2019.Game.Entities
{
    public class WaveStrategy
    {
        private readonly Player player;
        private readonly ITimeAdapter timeAdapter;
        private readonly IEnemyLoader enemyLoader;

        public WaveStrategy(Player player, ITimeAdapter timeAdapter, IEnemyLoader enemyLoader)
        {
            this.player = player;
            this.timeAdapter = timeAdapter;
            this.enemyLoader = enemyLoader;
        }

        private WaveResult CreateSkippedResult() =>
            new WaveResult()
            {
                Alive = false,
                VegansKilled = -1,
            };



        public async Task<WaveResult> PlayWave(Wave currentWave, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return CreateSkippedResult();
            }
            player.PlayerMPGenerator.Init();

            int enemiesKilled = 0;
            for (int i = 0; i < currentWave.Enemies.Length && !cancellationToken.IsCancellationRequested && player.Alive; i++)
            {
                await timeAdapter.Delay(1000, cancellationToken);
                var currentEnemy = currentWave.Enemies[i];
                var enemy = enemyLoader.LoadEnemy(currentEnemy.Type);
                enemiesKilled = i;
            }



            player.PlayerMPGenerator.Stop();
            return new WaveResult()
            {
                Alive = player.Alive,
                VegansKilled = enemiesKilled,
            };
        }

    }
}
