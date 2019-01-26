using GGJ2019.UnityGames.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace GGJ2019.UnityGames.GameTypes.Default
{

    public class DefaultGameStrategy : BaseGameType
    {
        public override Task EndAnimation(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public override Task StartAnimation(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}