using GGJ2019.Game.Adapters;
using GGJ2019.Game.Entities;
using UnityEngine;
using WorstGameStudios.Core.Abstractions.Engine.Coordinates;
using WorstGameStudios.Core.Utils.ExtensionMethods;
using Grid = GGJ2019.Game.Entities.Grid;
using UnityGrid = UnityEngine.Grid;

namespace GGJ2019.UnityGames.Adapters
{
    public class GridAdapter : MonoBehaviour, IGridAdapter
    {
        [SerializeField]
        private UnityGrid unityGrid;
        private Grid grid;

        public Grid Grid => grid;

        public void Init(int width, int height)
        {
            grid = new Grid(width, height);
            grid.Reset();
        }

        public (Vector worldPos, Cell cell) GridCoordinatesToWorldPosition(Vector gridCoords)
        {
            var cell = grid.GetCell((int)gridCoords.X, (int)gridCoords.Z);

            var worldPos = unityGrid.CellToWorld(new Vector3Int((int)gridCoords.X, (int)gridCoords.Y, (int)gridCoords.Z)).ToVector();

            return (worldPos, cell);
        }

        public (Vector gridCoords, Cell cell) WorldPositionToGridCoordinates(Vector worldPosition)
        {
            var gridCoords = new Vector((int)worldPosition.X, (int)worldPosition.Y, (int)worldPosition.Z);
            var cell = grid.GetCell((int)gridCoords.X, (int)gridCoords.Z);

            return (gridCoords, cell);
        }
    }
}
