using GGJ2019.Core.Adapters;
using GGJ2019.Core.Models;
using GGJ2019.Game.Adapters;
using GGJ2019.Game.Services;
using System.Threading;
using System.Threading.Tasks;

namespace GGJ2019.Game.Entities
{
    public class WaveStrategy
    {
        private readonly Player player;
        private readonly IGameUIAdapter gameUIadapter;
        private readonly ITimeAdapter timeAdapter;
        private readonly IEnemyLoader enemyLoader;
        private readonly IWeaponLoader weaponLoader;
        private readonly IInputService inputService;
        private readonly EnemySpawner enemySpawner;

        public WaveStrategy(Player player, IGameUIAdapter gameUIadapter, ITimeAdapter timeAdapter, IEnemyLoader enemyLoader, IWeaponLoader weaponLoader, IInputService inputService)
        {
            this.player = player;
            this.gameUIadapter = gameUIadapter;
            this.timeAdapter = timeAdapter;
            this.enemyLoader = enemyLoader;
            this.weaponLoader = weaponLoader;
            this.inputService = inputService;
        }

        private WaveResult CreateSkippedResult() =>
            new WaveResult()
            {
                Alive = false,
                VegansKilled = -1,
            };


        public async Task<WaveResult> PlayWave(IGameType gameType, Wave currentWave, CancellationToken cancellationToken)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                return CreateSkippedResult();
            }

            async void onTouch(Vector pos)
            {
                var selectedCell = gameType.GridAdapter.WorldPositionToGridCoordinates(pos);
                if(!selectedCell.cell.Available)
                {
                    return;
                }

                var cardsUI = gameUIadapter.CardsUIAdapter;
                async void onCardSelected(Weapon weapon)
                {
                    cardsUI.OnCardSelected -= onCardSelected;

                    var loadedWeapon = weaponLoader.LoadWeapon(weapon.WeaponType);
                    loadedWeapon.Position = selectedCell.gridCoords;

                    await cardsUI.Hide(cancellationToken);
                }

                cardsUI.OnCardSelected += onCardSelected;
                await cardsUI.Show(cancellationToken);


                
            }
            inputService.Setup();
            inputService.OnTouch += onTouch;

            player.PlayerMPGenerator.Init();

            int enemiesKilled = 0;

            var enemies = new IEnemy[currentWave.Enemies.Length];

            for (int i = 0; i < currentWave.Enemies.Length && !cancellationToken.IsCancellationRequested && player.Alive; i++)
            {
                //await timeAdapter.Delay(1000, cancellationToken);
                var currentEnemy = currentWave.Enemies[i];
                var enemy = enemyLoader.LoadEnemy(currentEnemy.Type);
                enemy.Animator.Walk();
                enemy.Movement.Position = new Vector(currentEnemy.Cell, 0, gameType.GridAdapter.Grid.Width * 3);
                enemies[i] = enemy;
                enemy.Init();

                await  enemy.WaitForCompletion(cancellationToken);

                enemiesKilled = i;
            }
            inputService.OnTouch -= onTouch;
            inputService.Dispose();

            player.PlayerMPGenerator.Stop();
            return new WaveResult()
            {
                Alive = player.Alive,
                VegansKilled = enemiesKilled,
            };
        }

    }
}
