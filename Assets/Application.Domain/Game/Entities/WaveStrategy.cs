using System.Threading;
using System.Threading.Tasks;

namespace GGJ2019.Game.Entities
{
    public class WaveStrategy
    {
        private readonly Player player;
        private readonly IEnemyLoader enemyLoader;

        public WaveStrategy(Player player, IEnemyLoader enemyLoader)
        {
            this.player = player;
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




            player.PlayerMPGenerator.Stop();
            return null;
        }

    }
}
