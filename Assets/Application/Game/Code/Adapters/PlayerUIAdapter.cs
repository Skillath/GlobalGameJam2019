using GGJ2019.Game.Adapters;
using GGJ2019.Game.Entities;
using UnityEngine;
using UnityEngine.UI;
using WorstGameStudios.Core.Engine.UI;
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
        /*[SerializeField]
        private TMP_Text lblMP;
        [SerializeField]
        private TMP_Text lblHP;*/

        [Inject]
        private void Inject(Player player)
        {
            this.player = player;

            slMP.maxValue = player.PlayerMPGenerator.MaxMP;
            slMP.value = player.PlayerMPGenerator.MP;

            slHP.maxValue = player.HP;
            slHP.value = player.HP;
        }

        public void Load()
        {
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


        public void Unload()
        {
            player.OnHPChanged -= Player_OnHPChanged;
            player.PlayerMPGenerator.OnMPValueChanged -= PlayerMPGenerator_OnMPValueChanged;
        }
    }
}
