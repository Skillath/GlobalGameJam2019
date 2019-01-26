using GGJ2019.Game.Adapters;
using GGJ2019.Game.Entities;
using GGJ2019.UnityCore.Entities;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GGJ2019.UnityGames.Adapters
{
    public class PlayerUIAdapter : View, IPlayerUIAdapter
    {
        private Player player;

        [SerializeField]
        private Slider slMP;
        [SerializeField]
        private Slider slHP;
        [SerializeField]
        private TMP_Text lblMP;
        [SerializeField]
        private TMP_Text lblHP;

        [Inject]
        private void Inject(Player player)
        {
            this.player = player;

            slMP.maxValue = player.PlayerMPGenerator.MaxMP;
            slMP.value = player.PlayerMPGenerator.MP;
        }

        protected override void Start()
        {
            base.Start();

            player.OnHPChanged += Player_OnHPChanged;
            player.PlayerMPGenerator.OnMPValueChanged += PlayerMPGenerator_OnMPValueChanged;
        }

        private void Player_OnHPChanged(int value)
        {
            slHP.value = value;
        }

        private void PlayerMPGenerator_OnMPValueChanged(int mp)
        {
            slMP.value = mp;
        }


        protected override void OnDestroy()
        {

            player.OnHPChanged -= Player_OnHPChanged;
            player.PlayerMPGenerator.OnMPValueChanged -= PlayerMPGenerator_OnMPValueChanged;
        }

        public override Task Hide(CancellationToken cancellationToken)
        {
            return base.Hide(cancellationToken);
        }

        public override Task Show(CancellationToken cancellationToken)
        {
            return base.Show(cancellationToken);
        }
    }
}
