using GGJ2019.Game.Adapters;
using GGJ2019.UnityCore.Entities;
using System;
using UnityEngine;

namespace GGJ2019.UnityGames.Adapters
{
    public class GameUIAdapter : View, IGameUIAdapter
    {
        [SerializeField]
        private PlayerUIAdapter playerUI;

        public IPlayerUIAdapter PlayerUIAdapter => playerUI;

        public void SetCurrentWave(int wave, int maxWave)
        {
            throw new NotImplementedException();
        }

        public void ShowLifePoins(int lifePoints)
        {
            throw new NotImplementedException();
        }
    }
}
