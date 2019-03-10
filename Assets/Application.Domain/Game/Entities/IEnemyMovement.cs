using WorstGameStudios.Core.Abstractions.Engine.Coordinates;

namespace GGJ2019.Game.Entities
{
    public interface IEnemyMovement
    {
        Vector Position { get; set; }

        bool CanMove { set; }

        float Speed { get; }
    }
}
