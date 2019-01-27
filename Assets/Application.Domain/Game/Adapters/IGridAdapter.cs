using GGJ2019.Core.Models;
using GGJ2019.Game.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
