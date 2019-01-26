using GGJ2019.Game.Adapters;
using UnityEngine;
using Zenject;
using Grid = GGJ2019.Game.Entities.Grid;

namespace GGJ2019.UnityGames.Adapters
{
    public class GridAdapter : MonoBehaviour, IGridAdapter
    {
        private Grid grid;

        [Inject]
        private void Inject(Grid grid)
        {
            this.grid = grid;
        }

        public void Init()
        {
            grid.Reset();
        }
    }
}
