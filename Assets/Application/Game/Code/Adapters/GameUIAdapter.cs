using GGJ2019.Game.Adapters;
using GGJ2019.Game.Entities;
using GGJ2019.UnityCore.Entities;
using System;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using Zenject;

namespace GGJ2019.UnityGames.Adapters
{
    public class GameUIAdapter : View, IGameUIAdapter
    {
        [SerializeField]
        private PlayerUIAdapter playerUI;
        [SerializeField]
        private CardsUIAdapter cardsUI;

        [Space]
        [SerializeField]
        private TMP_Text lblWaves;

        public IPlayerUIAdapter PlayerUIAdapter => playerUI;

        public ICardsUIAdapter CardsUIAdapter => cardsUI;

        [Inject]
        private void Inject(CardFactory factory) => CardsUIAdapter.Load((WeaponType[])Enum.GetValues(typeof(WeaponType)), factory);

        public void SetCurrentWave(int wave, int maxWave) => lblWaves.text = $"{wave}/{maxWave}";

        public override async Task Show(CancellationToken cancellationToken)
        {
            await base.Show(cancellationToken);
            await PlayerUIAdapter.Show(cancellationToken);
        }

        public override Task Hide(CancellationToken cancellationToken)
        {
            return Task.WhenAll(PlayerUIAdapter.Hide(cancellationToken), CardsUIAdapter.Hide(cancellationToken), base.Hide(cancellationToken));
        }
    }
}
