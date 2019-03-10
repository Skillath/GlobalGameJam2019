using GGJ2019.Game.Entities;
using WorstGameStudios.Core.Abstractions.Engine.Coordinates;

namespace GGJ2019.Game.Adapters
{
    public interface IGridAdapter
    {
        Grid Grid { get; }

        void Init(int width, int height);

        (Vector worldPos, Cell cell) GridCoordinatesToWorldPosition(Vector gridCoords);
        (Vector gridCoords, Cell cell) WorldPositionToGridCoordinates(Vector worldPosition);
    }
}
