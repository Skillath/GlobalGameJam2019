using GGJ2019.Game.Entities;
using GGJ2019.UnityCore.Entities;
using System;


namespace GGJ2019.UnityGames.Adapters
{
    public class GameUIAdapter : View, IGameUIAdapter
    {
        public void SetCurrentWave(int wave, int maxWave) => throw new NotImplementedException();
        public void ShowLifePoins(int lifePoints) => throw new NotImplementedException();
    }
}
