using GGJ2019.Game.Entities;
using WorstGameStudios.Core.Abstractions.Engine.UI;

namespace GGJ2019.Game.Adapters
{
    public interface IResultsUIAdapter : IWindow
    {
        void LoadResult(GameResult gameResults);
    }
}
