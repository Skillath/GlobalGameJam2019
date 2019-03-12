using GGJ2019.Game.Adapters;
using GGJ2019.Game.Entities;
using System.Threading;
using System.Threading.Tasks;
using WorstGameStudios.Core.Engine.UI;

namespace Assets.Application.Game.Code.Adapters
{
    public class ResultsUIAdapter : View, IResultsUIAdapter
    {
        private GameResult gameResults;

        public void LoadResult(GameResult gameResults)
        {
            this.gameResults = gameResults;
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
